using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string UnitName;

    public int MaxHP;
    public int CurrentHP;

    public int damage;
    public int spd;
    public int def;

    public bool TakeDamage(int dmg)
    {
        CurrentHP -= dmg;

        if (CurrentHP <= 0)
            return true;
        else
            return false;

    }
    
    public void Heal(int amount)
    {
        CurrentHP += amount;
        if(CurrentHP > MaxHP)
            CurrentHP = MaxHP;
    }
    
}
