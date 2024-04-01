using UnityEngine;
using System.Collections;

public class FireStomp : Move {
    private CameraShake camShake;

    public FireStomp(CameraShake camShake) : base("Fire Stomp", 0) {
        this.camShake = camShake;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;
        performer.enemy.TakeDamage(30);
        if (camShake) camShake.Shake(0.5f, 0.15f, 0.4f);

        return true;
    }
}