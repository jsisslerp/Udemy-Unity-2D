using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour {
    [SerializeField] private Defender defender;

    private void OnMouseDown()
    {
        foreach (DefenderButton button in FindObjectsOfType<DefenderButton>())
        {
            button.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().Defender = defender;
    }
}
