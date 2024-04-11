using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour {

	[SerializeField] TMPro.TMP_Text nameText;
	[SerializeField] Slider hpSlider;
	[SerializeField] TMPro.TMP_Text healthTxt;

	public void SetHUD(Unit unit) {
		nameText.text = unit.UnitName;
		hpSlider.maxValue = unit.MaxHP;
		hpSlider.value = unit.CurrentHP;
		if (healthTxt) healthTxt.text = unit.MaxHP.ToString();
	}

	public void SetHP(float hp) {
		hpSlider.value = hp;
		if (healthTxt) healthTxt.text = hp.ToString();
	}
}
