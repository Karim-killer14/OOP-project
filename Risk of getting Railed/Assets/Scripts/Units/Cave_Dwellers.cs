using UnityEngine;

public class Cave_Dwellers : Unit
{
    private void Awake()
    {
        YPos = -1.88f;
        UnitName = "Sewer Dwellers";
        MaxHP = 500;
        Moves = new Move[3];


        Moves[0] = new LightSwing();
        Moves[1] = new SkeleShield();
        Moves[2] = new ShroomHeal();

        //if (GameObject.Find("BattleSystem").GetComponent<BattleSystem>().state == BattleState.WON)
        //{

        //}
    }
}
