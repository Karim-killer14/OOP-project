using Unity.Mathematics;
using UnityEngine;

public class Unit : MonoBehaviour {
    [SerializeField] float dmgReduction = 0;
    public Move[] moves;
    private float currentHP;
    private float maxHP;

    public Unit enemy;
    public Animator animator;

    public string UnitName { get; set; }
    public float MaxHP {
        get { return maxHP; }
        set {
            maxHP = currentHP = value;
        }
    }

    public float CurrentHP {
        get { return currentHP; }
        set {
            currentHP = value;
            currentHP = math.min(math.max(currentHP, 0), MaxHP);
        }
    }

    public void TakeDamage(float dmg) {
        animator.SetTrigger("takeHit");
        CurrentHP -= dmg - (dmgReduction * dmg);

        if (CurrentHP <= 0) animator.SetTrigger("dead");
    }

    public virtual void IncrementCooldown() {
        foreach (var move in moves) {
            move.Cooldown++;
        }
    }
}