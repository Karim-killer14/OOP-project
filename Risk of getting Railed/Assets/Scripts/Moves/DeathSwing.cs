using UnityEngine;

public class DeathSwing : Move
{
    private readonly int[] dmgValues = { 20, 40,40,40,75,75 ,75,100 };
    public DeathSwing() : base("Death Swing", 0) { }

    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)]);
        return true;
    }
}