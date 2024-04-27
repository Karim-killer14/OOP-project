using System;
using UnityEngine;

public class EggGun : Move {

    private float[] dmgValues = { 2, 2, 2, 2, 2, 2, 2, 3, 4, 5, 3, 4, 5, 3, 4, 5, 10 };
    public EggGun(float dmgMult = 1) : base("Egg Gun", 3) {
        for (int i = 0; i < dmgValues.Length; i++) dmgValues[i] *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;


        GameObject.Find("Bullet Spawner").GetComponent<BulletSpawner>().shoot = true;
        for (int i = 0; i <= 10; i++) {
            performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)]);
        }

        return true;
    }
}