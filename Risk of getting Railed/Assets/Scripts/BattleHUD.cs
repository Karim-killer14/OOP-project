﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour {

	public Text nameText;
	public Slider hpSlider;

	public void SetHUD(Unit unit) {
		nameText.text = unit.UnitName;
		hpSlider.maxValue = unit.MaxHP;
		hpSlider.value = unit.CurrentHP;
	}

	public void SetHP(float hp) {
		hpSlider.value = hp;
	}
}
