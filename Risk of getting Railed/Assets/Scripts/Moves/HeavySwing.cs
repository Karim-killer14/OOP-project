using UnityEngine;

public class HeavySwing : Move {
    private readonly int damage = 90 * 9999;
    private CameraShake camShake;

    public HeavySwing() : base("Heavy Swing", 5) { 
        camShake = Camera.main.GetComponent<CameraShake>();
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(damage);
        camShake.Shake(0.075f, 0.7f, 0.15f);

        return true;    
    }
}