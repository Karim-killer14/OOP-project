using UnityEngine;

public class HeavySwing : Move {
    private readonly int damage = 90;

    public HeavySwing() : base("Heavy Swing", 5) { 
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(damage);
        Camera.main.GetComponent<CameraShake>().Shake(0.075f, 0.7f, 0.15f);

        return true;    
    }
}