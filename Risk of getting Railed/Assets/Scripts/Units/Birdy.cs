﻿using UnityEngine;

public class Birdy : Unit
{
    private void Awake()
    {
        YPos = -1.87f;
        UnitName = "Birdy Sabry";
        MaxHP = 200;

        Moves = new Move[1];

        Moves[0] = new LightSwing();
    }
}