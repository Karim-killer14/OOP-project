using UnityEngine;

public class LightSwing : Move {
    private readonly int damage = 20;
    public LightSwing() : base("Light Swing", 0) { }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(damage);

        Debug.Log(GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>().EnemyAtkMult);

        return true;
    }
}