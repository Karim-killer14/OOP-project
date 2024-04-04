using UnityEngine;

class RickScream : Move {
    private readonly AudioSource sound;
    private readonly int damage = 25;
    public RickScream(AudioSource sound) : base("Rick Scream", 0) { this.sound = sound; }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        sound.Play();

        performer.enemy.TakeDamage(damage);
        return true;
    }
}