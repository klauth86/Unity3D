using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    private List<int> _bowlResults;

    #region Cached
    [SerializeField] private Ball _ball;
    [SerializeField] private PinSetter _pinSetter;
    [SerializeField] private Text _scoreText;
    [SerializeField] private ScoreDisplay _scoreDisplay;
    #endregion

    [SerializeField] private float _waitPeriod = 1f;

    // Use this for initialization
    private void Start() {
        _pinSetter.RenewPins();
        _bowlResults = new List<int>();
    }

    // Update is called once per frame
    private void Update() {
        UpdateScoreText();
    }

    public void StartCountStanding() {
        StartCoroutine(CheckStanding());
    }

    private IEnumerator CheckStanding() {
        _scoreText.color = Color.red;
        var standingBeforeCount = Pin.CountStanding();
        var standingCount = -1;
        while (standingCount != Pin.CountStanding()) {
            standingCount = Pin.CountStanding();
            yield return new WaitForSeconds(_waitPeriod);
        }
        _scoreText.color = Color.green;
        var pinFall = standingBeforeCount - standingCount;
        _bowlResults.Add(pinFall);
        var action = ActionMaster2.NextAction(_bowlResults);
        Debug.Log("Action: " + pinFall + "(" + standingBeforeCount + ")" + " " + action);
        ActionAsActionMasterSay(action);
        _scoreDisplay.FillTheFrames(_bowlResults);
        _scoreDisplay.FillTheScores(ScoreMaster.GetCumulativeListOfFrameScores(_bowlResults));
        _ball.Reset();
    }

    private void ActionAsActionMasterSay(ActionMaster2.Action actionEnum) {
        switch (actionEnum) {
            case ActionMaster2.Action.Tidy:
                _pinSetter.Swipe();
                break;
            case ActionMaster2.Action.Reset:
                _pinSetter.Reset();
                break;
            case ActionMaster2.Action.EndTurn:
                _pinSetter.Reset();
                break;
            case ActionMaster2.Action.EndGame:
                break;
        }
    }

    private void UpdateScoreText() {
        if (_scoreText)
            _scoreText.text = Pin.CountStanding().ToString();
    }
}