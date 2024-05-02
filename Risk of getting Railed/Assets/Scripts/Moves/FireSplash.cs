using UnityEngine;

public class FireSplash : Move {
    private float damage = 30;
    private AudioSource fireBreathSnd;

    public FireSplash(AudioSource fireBreathSnd, float dmgMult=1) : base("Fire Splash", 4) {
        this.fireBreathSnd = fireBreathSnd;

        damage *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;
        performer.enemy.TakeDamage(damage);
        performer.enemy.Burn = 2;
        fireBreathSnd.Play();

        return true;
    }
}