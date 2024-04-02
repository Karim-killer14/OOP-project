using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour {

	public TextMeshProUGUI nameText;
    public TextMeshProUGUI HealthText;
    public Slider hpSlider;
	public TextMeshProUGUI StageText;

	public void SetHUD(Unit unit) {
		nameText.text = unit.UnitName;
		hpSlider.maxValue = unit.MaxHP;
		hpSlider.value = unit.CurrentHP;
	}

	public void SetHP(float hp) {
		hpSlider.value = hp;
    }

	/*public void SetSh(float sh)
	{
		shSlider.value = sh;
        ShieldText.text = $"{sh}";
    }*/

}
