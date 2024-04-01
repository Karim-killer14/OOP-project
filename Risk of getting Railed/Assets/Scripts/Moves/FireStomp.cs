using UnityEngine;
using System.Collections;

public class FireStomp : Move {
    private AudioSource stompSnd;
    private CameraShake camShake;

    public FireStomp(AudioSource stompSnd, CameraShake camShake) : base("Fire Stomp", 0) {
        this.stompSnd = stompSnd;
        this.camShake = camShake;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;
        performer.enemy.TakeDamage(30);
        if (camShake) camShake.Shake(0.5f, 0.15f, 0.4f);
        stompSnd.Play();

        return true;
    }
}