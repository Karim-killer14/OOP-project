using UnityEngine;

public class SkeleShield : Move
{
    public float shield = 30;
    public SkeleShield(float dmgMUlt=1) : base("SkeleShield", 4) { 
        shield *= dmgMUlt;
    }

    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;

        performer.CurrentSH += shield;

        return true;
    }
}