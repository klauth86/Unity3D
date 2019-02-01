using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {
    public enum ActionEnum { Tidy, Reset, EndTurn, EndGame, Undefined };
    public static int MaxPins = 10;

    private int[] _results = new int[22];
    private int _subTurn = 1;

    private ActionMaster() {

    }

    private ActionEnum Bowl(int pins) {

        if (pins < 0 || pins > MaxPins)
            throw new UnityException("Invalid pins count!");

        _results[_subTurn] = pins;

        if (_subTurn == 21 || _subTurn == 20 && !Frame21IsAwarded()) {
            return ActionEnum.EndGame;
        }

        if (_subTurn >= 19 && Frame21IsAwarded()) {
            _subTurn += 1;
            return _results[19] == MaxPins && _results[20] != MaxPins && _subTurn == 21 ? ActionEnum.Tidy : ActionEnum.Reset;
        }

        if (pins == MaxPins) {
            _subTurn += _subTurn % 2 == 0 ? 1 : 2;
            return ActionEnum.EndTurn;
        }

        _subTurn += 1;
        return _subTurn % 2 == 0 ? ActionEnum.Tidy : ActionEnum.EndTurn;
    }

    private bool Frame21IsAwarded() {
        return _results[19] + _results[20] >= MaxPins;
    }

    private void Reset() {
        _subTurn = 1;
        for (int i = 0; i < 22; i++) {
            _results[i] = 0;
        }
    }

    private static ActionEnum NextAction(IEnumerable<int> pinFalls) {
        var actionMaster = new ActionMaster();
        var result = ActionEnum.Undefined; 
        foreach (var item in pinFalls) {
            result = actionMaster.Bowl(item);
        }
        return result;
    }
}
