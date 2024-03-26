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
    public float shield;
    public int Cooldown {
        get { return cooldown; }
        set { cooldown = value; cooldown = math.min(cooldown, cooldownLimit); }
    }

    public Move(string attackName, string animName, int cooldownLimit, float damage, float heal, float shield)
    {
        this.attackName = attackName;
        this.animName = animName;
        this.damage = damage;
        this.heal = heal;
        this.cooldownLimit = cooldownLimit;
        this.Cooldown = cooldownLimit;
        this.shield = shield;
    }

    public virtual bool Perform(Unit performer) {
        if (Cooldown >= cooldownLimit) {
            performer.animator.SetTrigger(animName);
            Cooldown = -1;
            return true;
        }

        return false;
    }
}