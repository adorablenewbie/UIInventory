using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public ItemData curEquipData;

    private Character character;

    void Start()
    {
        character = GetComponent<Character>();
    }

    public void EquipNew(ItemData data)
    {
        UnEquip();
        curEquipData = data;
        UpdateEquipStat();
    }

    public void UnEquip()
    {
        UpdateUnEquipStat();
        if (curEquipData != null)
        {
            curEquipData = null;
        }
    }

    public void UpdateEquipStat()
    {
        if (curEquipData != null)
        {
            for (int i = 0; i < curEquipData.itemStats.Length; i++)
            {
                Debug.Log($"{character}");
                character.AddStat(curEquipData.itemStats[i].status, curEquipData.itemStats[i].value);
            }
        }

    }
    public void UpdateUnEquipStat()
    {
        if (curEquipData != null)
        {
            for (int i = 0; i < curEquipData.itemStats.Length; i++)
            {
                character.AddStat(curEquipData.itemStats[i].status, curEquipData.itemStats[i].value * -1);
            }
        }
    }
}