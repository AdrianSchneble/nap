using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class LevelUpTest {

    [Test]
    public void newCharacterIsFirstLevel()
    {
        GameObject go = new GameObject();
        go.AddComponent<PlayerController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        Assert.That(playerController.level == 1);
    }

    [Test]
    public void newCharacterhasZeroXP()
    {
        GameObject go = new GameObject();
        go.AddComponent<PlayerController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        Assert.That(playerController.xp == 0);
    }

    [Test]
    public void gainXP()
    {
        GameObject go = new GameObject();
        go.AddComponent<PlayerController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        playerController.gainXP(10);
        Assert.That(playerController.xp == 10);
    }

    [Test]
    public void CharakterWithSufficientXPLevelsUp()
    {
        GameObject go = new GameObject();
        go.AddComponent<PlayerController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        playerController.gainXP(60);
        Assert.That(playerController.level == 2);
    }

    [Test]
    public void MaxHPIsIncreasedOnLevelUp()
    {
        GameObject go = new GameObject();
        go.AddComponent<PlayerController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        playerController.gainXP(60);
        Assert.That(playerController.maxHp == 30);
    }

    [Test]
    public void MaxManaIsIncreasedOnLevelUp()
    {
        GameObject go = new GameObject();
        go.AddComponent<PlayerController>();
        PlayerController playerController = go.GetComponent<PlayerController>();
        playerController.gainXP(60);
        Assert.That(playerController.maxMana == 40);
    }

}
