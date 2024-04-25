using UnityEngine;


class SayGoodbye : Move {
    private readonly AudioSource sound;
    private readonly int[] dmgValues = { 0, 35, 80 };
    private CameraShake camShake;

    public SayGoodbye(AudioSource sound) : base("Say Goodbye", 3) {
        this.sound = sound;
        camShake = Camera.main.GetComponent<CameraShake>();
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        sound.Play();

        performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)]);
        camShake.Shake(0.1f, 0.25f, 1.1f);
        return true;
    }
}