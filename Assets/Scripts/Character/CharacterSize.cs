using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSize : MonoBehaviour
{
    private TextMeshProUGUI characterName;
    private Vector3 originalPosition, newPosition;
    private void Start()
    {
        characterName = GameObject.FindGameObjectWithTag("CharacterName").GetComponent<TextMeshProUGUI>();

        originalPosition = transform.position;

        newPosition = originalPosition;
        newPosition.y = 0.75f;
    }


    private void Update()
    {
        highlightCharacter();
    }

    private void highlightCharacter()
    {
        if (characterName.text == this.name || (this.name == "Captain" && characterName.text == "Tú"))
        {
            transform.localScale = Vector3.one * 1.25f;
            transform.position = newPosition;
        }
        else
        {
            transform.localScale = Vector3.one;
            transform.position = originalPosition;
        }
    }
}
