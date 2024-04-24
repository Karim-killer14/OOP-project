﻿using UnityEngine;

class LifeSteal : Move
{
    private readonly int[] dmgValues = { 50,50,50,100,100,100 };
    public LifeSteal() : base("Life Steal", 5) { }


    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;

        int healDmg = dmgValues[new System.Random().Next(dmgValues.Length)];
        performer.CurrentHP += healDmg;
        GameObject.Find("Hand Summon").GetComponent<Animator>().SetTrigger("Hand Attack");
        performer.enemy.TakeDamage(healDmg);



        return true;
    }
}