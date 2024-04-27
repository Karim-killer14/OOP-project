using UnityEngine;

class RickScream : Move {
    private readonly AudioSource sound;
    private float damage = 25;
    private CameraShake camShake;

    public RickScream(AudioSource sound, float dmgMult) : base("Rick Scream", 0) {
        this.sound = sound;
        camShake = Camera.main.GetComponent<CameraShake>();

        damage *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        sound.Play();

        performer.enemy.TakeDamage(damage);
        camShake.Shake(1.05f, 0.1f, 0.05f);
        return true;
    }
}