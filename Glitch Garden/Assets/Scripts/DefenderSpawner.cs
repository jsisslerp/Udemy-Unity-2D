using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderSpawner : MonoBehaviour {
    private Defender defender;
    private StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    public Defender Defender
    {
        get
        {
            return defender;
        }

        set
        {
            defender = value;
        }
    }

    private void OnMouseDown()
    {
        if (defender)
        {
            SpawnDefender(GetSquareClicked());
        }
    }

    Vector2 GetSquareClicked()
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        return new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        if (starDisplay.Stars >= defender.Cost)
        {
            starDisplay.Stars -= defender.Cost;
            Instantiate(defender, worldPos, Quaternion.identity);
        }
    }
}
