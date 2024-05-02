using UnityEngine;

public class ShroomHeal : Move
{
    private float heal = 30;
    public ShroomHeal(float dmgMult=1) : base("ShroomHeal", 4) { 
        heal *= dmgMult;
    }

    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;
        GameObject.Find("Mushroom Dude").GetComponent<Animator>().SetTrigger("Heal");
        performer.CurrentHP += heal;
        return true;
    }
}