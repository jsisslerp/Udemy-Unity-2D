using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {
    private Text healthText;

	// Use this for initialization
	void Start () {
        healthText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = Player.Instance.Health.ToString();
	}
}
