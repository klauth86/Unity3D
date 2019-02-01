using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {
    [SerializeField] Text[] _frameTexts;
    [SerializeField] Text[] _scoreTexts;

    public void FillTheFrames(List<int> bowls) {
        var formatted = FormatRolls(bowls);
        for (int i = 0; i < bowls.Count; i++) {
            _frameTexts[i].text = formatted[i].ToString();
        }
    }

    public void FillTheScores(List<int> scores) {
        for (int i = 0; i < scores.Count; i++) {
            _scoreTexts[i].text = scores[i].ToString();
        }
    }

    public static string FormatRolls(List<int> bowls) {
        string output = "";
        for (int i = 0; i < bowls.Count; i++) {
            if (bowls[i] == ActionMaster.MaxPins)
                output += output.Length >= 18 ? "X" : "X ";
            else if ((output.Length % 2 == 0 || output.Length == 19) && i + 1 < bowls.Count && bowls[i] + bowls[i + 1] == ActionMaster.MaxPins) {
                output += (bowls[i] == 0 ? "-" : bowls[i].ToString()) + "/";
                i++;
            }
            else {
                output += bowls[i] == 0 ? "-" : bowls[i].ToString();
            }
        }
        return output;
    }
}
