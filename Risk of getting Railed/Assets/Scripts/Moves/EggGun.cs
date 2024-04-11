using System;
using UnityEngine;

public class EggGun : Move
{

    private readonly int[] dmgValues = { 3, 4, 5, 3, 4, 5, 3, 4, 5, 10 };
    public float fireRate;
    public float timer = 0;
    public EggGun() : base("Egg Gun", 2) { }

    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;
        for (int i = 0; i <= 10; i++)
        {
            GameObject.Find("Bullet Spawner").GetComponent<BulletSpawner>().shoot = true;
            performer.enemy.TakeDamage(dmgValues[new System.Random().Next(dmgValues.Length)]);
        }

        
        return true;
    }
}