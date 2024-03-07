using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class statUI : MonoBehaviour
{

    public Text HP;
    public Text Dmg;
    public void SetHUD(Unit unit)
    {
        HP.text = unit.CurrentHP.ToString();
        Dmg.text = unit.damage.ToString();


    }
}
