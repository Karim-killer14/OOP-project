using UnityEngine;

public class FlyingSpin : Move
{
    private float[] dmgValues = { 25, 50, 50, 50, 75, 75, 75, 90 };
    private CameraShake camShake;
    public FlyingSpin(float dmgMult) : base("Spin", 5) {
        for (int i = 0; i < dmgValues.Length; i++)
            dmgValues[i] *= dmgMult;
    }


    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)]);
        GameObject.Find("Flying Eye").GetComponent<Animator>().SetTrigger("Spin");
        return true;
    }
}