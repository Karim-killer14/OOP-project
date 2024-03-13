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
        CurrentHP = CurrentHP - dmg;

        if (CurrentHP <= 0) 
        {
            CurrentHP = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetMaxHP()
    {
        return MaxHP;
    }

    public void Heal(int amount, int maxHP)
    {
        CurrentHP += amount;
        if (CurrentHP > maxHP)
        {
            CurrentHP = maxHP;
        }
    }

}
