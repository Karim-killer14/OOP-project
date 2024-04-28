using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Color Pcolor;
    public Color Mcolor;
    public string[] lines;
    public float textSpeed;

    private int index;

    public GameObject Phealth; 
    public GameObject Ehealth;
    public GameObject TurnCounter;
    public GameObject Moves;
    public GameObject LoadButton;
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index]) 
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        if(index == 12)
        {
            Phealth.SetActive(true);
        }
        if (index == 13)
        {
            Phealth.SetActive(false);
            Ehealth.SetActive(true);
        }
        if (index == 14)
        {
            Ehealth.SetActive(false);
            // TurnCounter.SetActive(true);
        }
        if (index == 15)
        {
            // TurnCounter.SetActive(false);
            Moves.SetActive(true);
        }
        if (index == 16)
        {
            Moves.SetActive(false);
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index == 0 || index == 1 || index == 2 || index == 4 || index ==8 || index == 17)
        {
            textComponent.color = Pcolor;
        }
        else
        {
            textComponent.color = Mcolor;
        }
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            LoadButton.SetActive(true);
            
        }

    }
}
