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
            if (currentHP <= 0) currentHP = 0;
        }
    }

    public void TakeDamage(float dmg) {
        animator.SetTrigger("takeHit");
        CurrentHP -= dmg - (dmgReduction * dmg);

        if (CurrentHP <= 0) animator.SetTrigger("dead");
    }

    public void Heal(float amount, float maxHP) {
        CurrentHP += amount;
        if (CurrentHP > maxHP) {
            CurrentHP = maxHP;
        }
    }

    public virtual void Attack(int attackID, float damage = 0) {
        animator.SetTrigger($"attack{attackID}");
        enemy.TakeDamage(damage);
    }

    public virtual void Heal(float amount) {
        currentHP += amount;
    }
}