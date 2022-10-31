using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlaceCharacter : MonoBehaviour
{

    [System.Serializable]
    public struct Characters
    {
        public string name;
        public GameObject characterPrefab;
    }

    public Characters[] characters;

    private Vector3 left;
    private Vector3 right;

    private void Start()
    {
        left = new Vector3(-5.36f, -0.35f, 0);
        right = new Vector3(5.36f, -0.35f, 0);
    }

    [YarnCommand("place")]
    public void PlaceCharacterPrefab(string characterName, string position)
    {
        foreach (var info in characters)
        {
            if (info.name == characterName)
            {
                if (position == "left")
                {
                    GameObject newCharacter = (GameObject)Instantiate(info.characterPrefab, left, transform.rotation);
                    newCharacter.name = characterName;
                } else if (position == "right")
                {
                    GameObject newCharacter = (GameObject)Instantiate(info.characterPrefab, right, transform.rotation);
                    newCharacter.name = characterName;
                } else
                {
                    Debug.LogWarning(position + " must be left or right");
                }
                break;
            }
        }
    }

    [YarnCommand("destroy")]
    public void DestroyCharacterPrefab(string characterName)
    {
        GameObject[] charactersCurrentlyInScene = GameObject.FindGameObjectsWithTag("Character");

        foreach (var character in charactersCurrentlyInScene)
        {
            if (character.name == characterName)
            {
                Destroy(character);
                break;
            }
        }
    }
}
