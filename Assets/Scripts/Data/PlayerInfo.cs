using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EJob
{
    코린이
}

public enum EItem
{

}

[CreateAssetMenu(fileName ="NewPlayerData", menuName = "New Player Data")]
public class PlayerInfo : ScriptableObject
{
    public string playerName;
    public EJob job;
    public int level;
    public float exp;
    public int gold;
    public int slots;
    public float health;
    public float attack;
    public float defense;
    public float critical;
    public float speed;
    public float avoid;
}
