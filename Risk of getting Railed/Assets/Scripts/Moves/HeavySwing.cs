using UnityEngine;

public class HeavySwing : Move {
    private float damage = 90;

    public HeavySwing(float dmgMult = 1) : base("Heavy Swing", 5) {
        damage *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(damage);
        Camera.main.GetComponent<CameraShake>().Shake(0.075f, 0.7f, 0.15f);

        return true;
    }
}