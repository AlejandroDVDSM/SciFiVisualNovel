using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSize : MonoBehaviour
{
    private TextMeshProUGUI characterName;

    private void Start()
    {
        characterName = GameObject.FindGameObjectWithTag("CharacterName").GetComponent<TextMeshProUGUI>();
        transform.localScale = Vector3.one;
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
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
}
