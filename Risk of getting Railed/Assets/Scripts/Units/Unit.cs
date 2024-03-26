using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Unit : MonoBehaviour {
    [SerializeField] float dmgReduction = 0;
    public Move[] moves;
    private float currentHP;
    private float maxHP;
    private float currentSH;

    public Unit enemy;
    public Animator animator;

    public string UnitName { get; set; }
    public float MaxHP {
        get { return maxHP; }
        set {
            maxHP = currentHP = value;
        }
    }
    public float CurrentSH
    {
        get { return currentSH; }
        set
        {
            currentSH = value;
            Debug.Log($"SH value ={currentSH}");
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
        if (CurrentSH >= dmg)
        {
            CurrentSH -= dmg;
        }

        else if (dmg > CurrentSH)
        {
            float totdmg = dmg - CurrentSH;
            animator.SetTrigger("takeHit");
            CurrentHP -= totdmg - (dmgReduction * totdmg);
        }
        if (CurrentHP <= 0) animator.SetTrigger("dead");
    }

    public virtual void IncrementCooldown() {
        foreach (var move in moves) {
            move.Cooldown++;
        }
    }
}