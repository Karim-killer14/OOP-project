using System;
using Unity.Mathematics;
using UnityEngine;

public class Move : MonoBehaviour {
    public string attackName;
    public int cooldownLimit;
    private int cooldown;
    public int Cooldown {
        get { return cooldown; }
        set { cooldown = value; cooldown = math.min(cooldown, cooldownLimit); }
    }

    public Move(string attackName, int cooldownLimit) {
        this.attackName = attackName;
        this.cooldownLimit = cooldownLimit;
        this.Cooldown = cooldownLimit;
    }

    public bool CanUse() { return Cooldown >= cooldownLimit; }
    public void ResetCooldown() { Cooldown = cooldownLimit; }

    public virtual bool Perform(Unit performer) {
        if (CanUse()) {
            performer.animator.SetTrigger(attackName);
            Cooldown = -1;
            return true;
        }

        return false;
    }
}