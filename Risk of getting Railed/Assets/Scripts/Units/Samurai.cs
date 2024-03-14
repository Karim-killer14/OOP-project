using UnityEngine;


public class Samurai : Unit {
    private void Awake() {
        UnitName = "Samurai";
        MaxHP = 100;
    }

    public override void Attack(int attackID, float damage = 0) {
        if (attackID == 0) damage = 10; // light swing
        else if (attackID == 1) damage = 30; // heavy swing

        base.Attack(attackID, damage);
    }

    public override void Heal(float amount) {
        base.Heal(amount);
    }
}