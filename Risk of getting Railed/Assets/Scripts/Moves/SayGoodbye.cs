using UnityEngine;

class SayGoodbye : Move {
    private readonly AudioSource sound;
    private readonly int[] dmgValues = { 0, 50, 100 };

    public SayGoodbye(AudioSource sound) : base("Say Goodbye", 3) { this.sound = sound; }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        sound.Play();

        performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)]);
        return true;
    }
}