using UnityEngine;

class LifeSteal : Move {
    private float[] dmgValues = { 25, 25, 50 };
    private CameraShake camShake;
    public LifeSteal(float dmgMult=1) : base("Life Steal", 3) {
        camShake = Camera.main.GetComponent<CameraShake>();

        for (int i = 0; i < dmgValues.Length; i++) dmgValues[i] *= dmgMult;
    }


    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        float healDmg = dmgValues[new System.Random().Next(dmgValues.Length)];
        performer.CurrentHP += healDmg;
        GameObject.Find("Hand Summon").GetComponent<Animator>().SetBool("Hand Attack", true);
        camShake.Shake(0.2f, 1.0f, 0.1f);
        performer.enemy.TakeDamage(healDmg);

        return true;
    }
}