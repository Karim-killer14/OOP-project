using UnityEngine;

public class SkeleShield : Move
{
    public float shield = 4;
    public SkeleShield() : base("SkeleShield", 4) { }

    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;

        performer.CurrentSH += shield;

        return true;
    }
}