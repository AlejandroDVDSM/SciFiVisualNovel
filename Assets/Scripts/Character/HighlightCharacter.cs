using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighlightCharacter : MonoBehaviour
{
    private TextMeshProUGUI characterName;
    private bool isAlreadyHighlighted = false;

    public bool IsAlreadyHighlighted { get => isAlreadyHighlighted; }

    private void Start()
    {
        characterName = GameObject.FindGameObjectWithTag("CharacterName").GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        Highlight();
    }

    private void Highlight()
    {
        if (characterName.text == this.name || (this.name == "Captain" && characterName.text == "Tú"))
        {
            isAlreadyHighlighted = true;
        } else
        {
            isAlreadyHighlighted = false;
        }
    }
}
