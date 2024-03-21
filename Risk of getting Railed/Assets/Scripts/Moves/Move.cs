using System;
using UnityEngine;

public class Move : MonoBehaviour {
    public string attackName;
    public float damage;
    public float heal;

    public Move(string attackName, float damage, float heal) {
        this.attackName = attackName;
        this.damage = damage;
        this.heal = heal;
    }

    public virtual bool Perform() {
        // todo handle cooldown here and return false if not perofrmed correctly
        return true;
    }
}