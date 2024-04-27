using UnityEngine;

public class DeathSwing : Move {
    private float[] dmgValues = { 20, 20,30,30,30,30,40, 40, 40, 40, 40,50 , 50 };
    private CameraShake camShake;

    public DeathSwing(float dmgMult = 1) : base("Death Swing", 0) {
        camShake = Camera.main.GetComponent<CameraShake>();

        for(int i = 0; i < dmgValues.Length; i++) dmgValues[i] *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)]);
        camShake.Shake(0.1f, 0.5f, 0.5f);
        return true;
    }
}