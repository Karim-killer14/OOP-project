using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class script : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject Btn;
    public string[] lines;
    public float textSpeed;

    public GameObject Credits;

    private int index;
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
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
        if (index < lines.Length - 1 )
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Credits.SetActive(true);
            textComponent.text = "";
            Btn.SetActive(true);
        }

    }
}
