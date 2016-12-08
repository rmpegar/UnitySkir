using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public List<BaseStat> stats = new List<BaseStat>();

    void Start()
    {
        stats.Add(new BaseStat(4, "Power", "Your power level."));
        stats.Add(new BaseStat(2, "Health", "Your character's health."));
        Debug.Log(stats[0].GetCalculatedStatValue());
        //Debug.Log(stats[1].GetCalculatedStatValue());
        //Debug.Log(stats[2].GetCalculatedStatValue());
    }

    //Called when we equip a sword
    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            stats.Find(x => x.StatName == statBonus.StatName)
                .AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    //Called when we unequip a sword
    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            stats.Find(x => x.StatName == statBonus.StatName)
                .RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}
