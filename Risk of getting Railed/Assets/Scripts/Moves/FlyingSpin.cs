using UnityEngine;

public class FlyingSpin : Move
{
    private readonly int[] dmgValues = { 20, 50, 50, 50, 75, 75, 75, 100 };
    private CameraShake camShake;
    public FlyingSpin() : base("Spin", 5) { }
    

    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)]);
        GameObject.Find("Flying Eye").GetComponent<Animator>().SetTrigger("Spin");       
        return true;
    }
}