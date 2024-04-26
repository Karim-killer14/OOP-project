using UnityEngine;

public class ShroomHeal : Move
{
    private readonly int heal = 40;
    public ShroomHeal() : base("ShroomHeal", 4) { }

    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;
        GameObject.Find("Mushroom Dude").GetComponent<Animator>().SetTrigger("Heal");
        performer.CurrentHP += heal;
        return true;
    }
}