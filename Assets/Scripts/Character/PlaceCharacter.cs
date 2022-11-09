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
        left = new Vector3(-5.36f, 0, 0);
        right = new Vector3(5.36f, 0, 0);
    }

    [YarnCommand("place")]
    public void PlaceCharacterPrefab(string characterName, string position)
    {
        GameObject newCharacter = null;

        foreach (var info in characters)
        {
            if (info.name == characterName)
            {
                if (position == "left")
                {
                    newCharacter = (GameObject)Instantiate(info.characterPrefab, left, transform.rotation);
                    newCharacter.GetComponent<FadeCharacter>().FadeIn();
                    newCharacter.name = info.name;
                } else if (position == "right")
                {
                    newCharacter = (GameObject)Instantiate(info.characterPrefab, right, transform.rotation);
                    newCharacter.GetComponent<FadeCharacter>().FadeIn();
                    newCharacter.name = info.name;
                } else
                {
                    Debug.LogErrorFormat("Position must be 'left' or 'right' but instead {0} was received", position);
                }
                break;
            }
        }

        if (newCharacter == null)
        {
            Debug.LogErrorFormat("Can't find character named {0}!", characterName);
            return;
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
                character.GetComponent<FadeCharacter>().FadeIn();
                Destroy(character);
                break;
            }
        }
    }
}
