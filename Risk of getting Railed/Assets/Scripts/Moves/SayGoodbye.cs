using UnityEngine;


class SayGoodbye : Move {
    private readonly AudioSource sound;
    private float[] dmgValues = { 0, 35, 80 };
    private CameraShake camShake;

    public SayGoodbye(AudioSource sound, float dmgMult) : base("Say Goodbye", 3) {
        this.sound = sound;
        camShake = Camera.main.GetComponent<CameraShake>();

        for(int i = 0; i < dmgValues.Length; i++) dmgValues[i] *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        sound.Play();

        performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)]);
        camShake.Shake(0.1f, 0.25f, 1.1f);
        return true;
    }
}