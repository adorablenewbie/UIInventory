using System;
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

    public Equipment equip;


    private void Start()
    {
        equip = GetComponent<Equipment>();
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
    
    public void AddStat(EStatus eStatus, float value)
    {
        switch (eStatus)
        {
            case EStatus.Health:
                health += value;
                break;
            case EStatus.Attack:
                attack += value;
                break;
            case EStatus.Defense:
                defense += value;
                break;
            case EStatus.Critical:
                critical += value;
                break;
            case EStatus.Speed:
                speed += value;
                break;
            case EStatus.Avoid:
                avoid += value;
                break;
        }
    }
}
