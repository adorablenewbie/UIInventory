using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EStatus
{
    Health,
    Attack,
    Defense,
    Critical,
    Speed,
    Avoid
}

[Serializable]
public class ItemStat
{
    public EStatus status;
    public float value;
}


[CreateAssetMenuAttribute(fileName ="NewItemData", menuName = "New Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite icon;
    public ItemStat[] itemStats;
    
}
