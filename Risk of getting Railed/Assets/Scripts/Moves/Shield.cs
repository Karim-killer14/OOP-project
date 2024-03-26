using UnityEngine;

public class Shield : Move
{
    public Shield() : base("Shield", "heal", 0, 0, 0,100) { }

    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;

        performer.CurrentSH += shield;

        return true;
    }
}