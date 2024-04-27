using UnityEngine;
using System.Collections;

public class FireStomp : Move {
    private AudioSource stompSnd;
    private CameraShake camShake;
    private float damage = 30;

    public FireStomp(AudioSource stompSnd, float dmgMult) : base("Fire Stomp", 0) {
        this.stompSnd = stompSnd;
        camShake = Camera.main.GetComponent<CameraShake>();

        damage *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;
        performer.enemy.TakeDamage(damage);
        camShake.Shake(0.5f, 0.15f, 0.4f);
        stompSnd.Play();

        return true;
    }
}