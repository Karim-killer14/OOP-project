using UnityEngine;

class RickScream : Move {
    private readonly AudioSource sound;
    private readonly int damage = 25;
    private CameraShake camShake;

    public RickScream(AudioSource sound) : base("Rick Scream", 0) {
        this.sound = sound;
        camShake = Camera.main.GetComponent<CameraShake>();
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        sound.Play();

        performer.enemy.TakeDamage(damage);
        camShake.Shake(1.05f, 0.1f, 0.05f);
        return true;
    }
}