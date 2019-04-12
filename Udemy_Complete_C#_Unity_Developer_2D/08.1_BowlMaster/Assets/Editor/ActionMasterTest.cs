using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class ActionMaster2Test {
    private ActionMaster2.Action endTurn = ActionMaster2.Action.EndTurn;
    private ActionMaster2.Action tidy = ActionMaster2.Action.Tidy;
    private ActionMaster2.Action reset = ActionMaster2.Action.Reset;
    private ActionMaster2.Action endGame = ActionMaster2.Action.EndGame;

    [Test]
    public void PassingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01FirstStrikeReturnsEndTurn() {
        Assert.AreEqual(endTurn, ActionMaster2.NextAction(new List<int>() { 10 }));
    }

    [Test]
    public void T02Bowl8ReturnsTidy() {
        Assert.AreEqual(tidy, ActionMaster2.NextAction(new List<int>() { 8 }));
    }

    [Test]
    public void T03Bowl8And1ReturnsEndTurn() {
        Assert.AreEqual(endTurn, ActionMaster2.NextAction(new List<int>() { 8, 1 }));
    }

    //[Test]
    //public void T04InvalidPinCountOnFrameReturnsException() {
    //    ActionMaster2.Bowl(8);
    //    Assert.Catch(typeof(UnityException), ()=> { ActionMaster2.Bowl(8); });
    //}

    [Test]
    public void T05CheckResetAtStrikeInLastFrame() {
        Assert.AreEqual(reset, ActionMaster2.NextAction(new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 }));
    }

    [Test]
    public void T06CheckResetAtSpareInLastFrame() {
        Assert.AreEqual(reset, ActionMaster2.NextAction(new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 }));
    }

    [Test]
    public void T07YouTubeRollsEndInEndGame() {
        Assert.AreEqual(endGame, ActionMaster2.NextAction(new List<int>() { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 }));
    }

    [Test]
    public void T08GameEndsAtBowl20() {
        Assert.AreEqual(endGame, ActionMaster2.NextAction(new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
    }

    [Test]
    public void T09DarylBowl20Test() {
        Assert.AreEqual(tidy, ActionMaster2.NextAction(new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5 }));
    }

    [Test]
    public void T10BensBowl20Test() {
        Assert.AreEqual(tidy, ActionMaster2.NextAction(new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 }));
    }

    [Test]
    public void T11NathanBowl20Test() {
        Assert.AreEqual(tidy, ActionMaster2.NextAction(new List<int>() { 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 2 }));
    }

    [Test]
    public void T11NathanBowlIndexTest() {
        Assert.AreEqual(endTurn, ActionMaster2.NextAction(new List<int>() { 0, 10, 5, 2 }));
    }

    [Test]
    public void T12Dondi10thFrameTurkey() {
        Assert.AreEqual(reset, ActionMaster2.NextAction(new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 }));
        Assert.AreEqual(reset, ActionMaster2.NextAction(new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10 }));
        Assert.AreEqual(endGame, ActionMaster2.NextAction(new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 }));
    }
}
