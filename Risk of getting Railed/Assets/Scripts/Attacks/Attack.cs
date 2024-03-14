using System;
using UnityEngine;

public class Attack : MonoBehaviour {
    protected string attackName;
    protected string type; // fire air sword heal 
    protected float damage;

    public Attack(string attackName, string type, float damage) {
        this.attackName = attackName;
        this.type = type;
        this.damage = damage;
    }
}