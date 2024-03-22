using System;
using UnityEngine;

public class Move : MonoBehaviour {
    public string attackName;
    public float damage;
    public float heal;
    protected string animName;

    public Move(string attackName, string animName, float damage, float heal) {
        this.attackName = attackName;
        this.animName = animName;
        this.damage = damage;
        this.heal = heal;
    }

    public virtual bool Perform(Unit performer) {
        if(false) return false; // here handle cooldown, return false to indicate failure
        performer.animator.SetTrigger(animName);


        return true;
    }
}