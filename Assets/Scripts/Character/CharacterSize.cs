using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSize : MonoBehaviour
{
    private TextMeshProUGUI characterName;
    private bool isAlreadyHighlighted = false;

    private void Start()
    {
        characterName = GameObject.FindGameObjectWithTag("CharacterName").GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        highlightCharacter();
    }

    private void highlightCharacter()
    {
        if (characterName.text == this.name || (this.name == "Captain" && characterName.text == "Tú"))
        {
            if (!isAlreadyHighlighted)
            {
                transform.localScale = Vector3.one * 1.25f;
                isAlreadyHighlighted = true;
            }
        }
        else
        {
            transform.localScale = Vector3.one;
            isAlreadyHighlighted = false;
        }
    }
}
