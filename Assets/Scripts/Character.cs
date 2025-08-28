using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string playerName {  get; private set; }
    public EJob job { get; private set; }
    public int level { get; private set; }
    public float exp {  get; private set; }
    public int gold { get; private set; }
    public float health { get; private set; }
    public float attack { get; private set; }
    public float defense { get; private set; }
    public float critical { get; private set; }
    public float speed { get; private set; }
    public float avoid { get; private set; }

    public PlayerInfo playerInfo;


    private void Start()
    {
        InitializeData();
        GameManager.Instance.character = this;
    }

    public float CalculateGoalExp()
    {
        return (level / 5 * 100) + (level % 5 * 10);
    }

    void InitializeData()
    {
        playerName = playerInfo.playerName;
        job = playerInfo.job;
        level = playerInfo.level;
        exp = playerInfo.exp;
        gold = playerInfo.gold;
        health = playerInfo.health;
        attack = playerInfo.attack;
        defense = playerInfo.defense;
        critical = playerInfo.critical;
        speed = playerInfo.speed;
        avoid = playerInfo.avoid;
    }
}
