using UnityEngine;
using System.Collections;

public class FireStomp : Move {
    private AudioSource stompSnd;
    public float damage = 30;

    public FireStomp(AudioSource stompSnd, float dmgMult=1) : base("Fire Stomp", 0) {
        this.stompSnd = stompSnd;

        damage *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;
        performer.enemy.TakeDamage(damage);
        Camera.main.GetComponent<CameraShake>().Shake(0.5f, 0.15f, 0.4f);
        stompSnd.Play();

        return true;
    }
}