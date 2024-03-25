using System;
using Unity.Mathematics;
using UnityEngine;

public class Move : MonoBehaviour {
    public string attackName;
    public float damage;
    public float heal;
    protected string animName;
    protected int cooldownLimit;
    private int cooldown;
    public int Cooldown {
        get { return cooldown; }
        set { cooldown = value; cooldown = math.min(cooldown, cooldownLimit); }
    }

    public Move(string attackName, string animName, int cooldownLimit, float damage, float heal) {
        this.attackName = attackName;
        this.animName = animName;
        this.damage = damage;
        this.heal = heal;
        this.cooldownLimit = cooldownLimit;
        this.Cooldown = cooldownLimit;
    }

    public bool CanUse() { return Cooldown >= cooldownLimit; }

    public virtual bool Perform(Unit performer) {
        if (CanUse()) {
            performer.animator.SetTrigger(animName);
            Cooldown = -1;
            return true;
        }

        return false;
    }
}