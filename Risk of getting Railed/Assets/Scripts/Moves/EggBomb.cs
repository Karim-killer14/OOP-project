using UnityEngine;

public class EggBomb : Move
{
    private float[] dmgValues = { 35, 35, 35, 35, 35, 35, 35, 100, 100, 100, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 125 }; 
    public EggBomb(float dmgMult=1) : base("Egg bomb", 5) { 
        for(int i = 0; i < dmgValues.Length; i++) dmgValues[i] *= dmgMult;  
    }
    
    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;

        GameObject.Find("Egg").GetComponent<Animator>().SetTrigger("Egg bomb");
        performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)] * performer.dmgMultiplier);
        return true;
    }
}