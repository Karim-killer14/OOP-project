using UnityEngine;


public class Sabry : Unit {
    private void Awake() {
        UnitName = "Sabry";
        MaxHP = 100;
    }

    public override void Attack(int attackID, float damage = 0) {
        if (attackID == 0) {
            damage = 20;
        }

        base.Attack(attackID, damage);
    }
}