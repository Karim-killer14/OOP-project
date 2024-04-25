using Unity.Mathematics;
using UnityEngine;
using System.Collections.Generic;


public class Unit : MonoBehaviour {
    private float dmgReduction = 0;
    public float DmgReduction { get { return dmgReduction; } set { dmgReduction = math.max(0, value); } }
    private float yPos = 0;
    public float YPos { get { return yPos; } set { yPos = value; } }
    private int burn = 0;


    public int Burn {
        get { return burn; }
        set {
            if (value > 0) {
                burn = value;
                // todo enable fire effect for character
                return;
            }

            burn = 0;
            // todo disable fire effect for dis character
        }
    }

    public string UnitName { get; set; }
    public List<Move> Moves { get; set; } = new List<Move>();
    private float currentHP;
    private float maxHP;
    private float currentSH;
    private float maxSH;//if max hp is 100 then max sh is maybe 200 (this is only useful for shield slider) and enemy shields ig

    public Unit enemy;
    public Animator animator;

    // Buffs related
    public float dmgMultiplier = 1;
    public float RngDmgMultChance { get; set; } = 1;

    public float MaxHP {
        get { return maxHP; }
        set { maxHP = currentHP = value; }
    }
    public float CurrentHP {
        get { return currentHP; }
        set {
            currentHP = value;
            currentHP = math.min(math.max(currentHP, 0), MaxHP);
        }
    }
    public float MaxSH {
        get { return maxSH; }
        set { maxSH = value; }
    }
    public float CurrentSH {
        get { return currentSH; }
        set {
            currentSH = value;
            Debug.Log($"SH value ={currentSH}");
        }
    }

    public void TakeDamage(float dmg) {
        dmg *= this.enemy.dmgMultiplier * (UnityEngine.Random.Range(0.0f, 1.0f) <= this.enemy.RngDmgMultChance ? 1 : 1 / this.enemy.dmgMultiplier);

        if (CurrentSH >= dmg) {
            CurrentSH -= dmg;
        }

        else if (dmg > CurrentSH) {
            float totdmg = dmg - CurrentSH;
            animator.SetTrigger("takeHit");
            CurrentHP -= totdmg - (DmgReduction * totdmg) + totdmg * (Burn / 3.0f);
            Burn--;
        }
        if (CurrentHP <= 0) animator.SetTrigger("dead");
    }
    public virtual void IncrementCooldown() {
        foreach (var move in Moves) {
            move.Cooldown++;
        }
    }
    public void aiAttack() {
        System.Random rand = new();
        int i = rand.Next(Moves.Count);
        while (!Moves[i].CanUse()) i = rand.Next(Moves.Count);

        Moves[i].Perform(this);

    }
    public void Reset() {
        foreach (var move in Moves)
            move.ResetCooldown();
        CurrentHP = MaxHP;
    }
}