using UnityEngine;

public class FireSplash : Move {
    private AudioSource fireBreathSnd;
    public FireSplash(AudioSource fireBreathSnd) : base("Fire Splash", 5) {
        this.fireBreathSnd = fireBreathSnd;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;
        performer.enemy.TakeDamage(20);
        performer.enemy.Burn = 2;
        fireBreathSnd.Play();

        return true;
    }
}