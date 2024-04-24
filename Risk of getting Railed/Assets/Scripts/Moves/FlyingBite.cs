using UnityEngine;

class FlyingBite : Move
{
    private readonly int[] dmgValues = { 50, 50, 50, 100, 100, 100 };
    public FlyingBite() : base("Flying Bite", 5) { }


    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;

        GameObject.Find("Flying Friend").GetComponent<Animator>().SetTrigger("Bite");
        performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)]);



        return true;
    }
}
