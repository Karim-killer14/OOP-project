﻿using UnityEngine;

public class EggBomb : Move
{
    private readonly int[] dmgValues = { 35, 35, 35, 35, 35, 35, 35, 100, 100, 100, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 125 }; 
    public EggBomb() : base("Egg bomb", 5) { }
    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;

        GameObject.Find("Egg").GetComponent<Animator>().SetTrigger("Egg bomb");
        performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)] * performer.dmgMultiplier);
        return true;
    }
}