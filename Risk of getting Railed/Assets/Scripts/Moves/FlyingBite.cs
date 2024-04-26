using UnityEngine;

public class FlyingBite : Move
{
    private readonly int[] dmgValues = { 20, 40, 40, 40, 75, 40, 75, 40,40,40 };
    private CameraShake camShake;
    public FlyingBite() : base("Bite", 2)
    {
        camShake = Camera.main.GetComponent<CameraShake>();
    }

    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)]);
        GameObject.Find("Flying Eye").GetComponent<Animator>().SetTrigger("Bite");

        camShake.Shake(0.1f, 0.5f, 0.5f);
        return true;
    }
}