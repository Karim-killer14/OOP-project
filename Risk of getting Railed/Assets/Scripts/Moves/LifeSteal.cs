using UnityEngine;

class LifeSteal : Move {
    private readonly int[] dmgValues = { 50, 100 };
    private CameraShake camShake;
    public LifeSteal() : base("Life Steal", 5) {
        camShake = Camera.main.GetComponent<CameraShake>();
    }


    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        int healDmg = dmgValues[new System.Random().Next(dmgValues.Length)];
        performer.CurrentHP += healDmg;
        GameObject.Find("Hand Summon").GetComponent<Animator>().SetBool("Hand Attack", true);
        camShake.Shake(0.2f, 1.0f, 0.1f);
        performer.enemy.TakeDamage(healDmg);

        return true;
    }
}