using UnityEngine;

public class Cave_Dwellers : Unit {
    private void Awake() {
        YPos = -1.88f;
        UnitName = "Sewer Dwellers";
        MaxHP = 500;

        Moves.Add(new LightSwing());
        Moves.Add(new SkeleShield());
        Moves.Add(new ShroomHeal());

        //if (GameObject.Find("BattleSystem").GetComponent<BattleSystem>().state == BattleState.WON)
        //{

        //}
    }
}
