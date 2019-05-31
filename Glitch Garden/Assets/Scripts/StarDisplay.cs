using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {
    [SerializeField] private int stars = 100;
    private Text starText;

    public int Stars
    {
        get
        {
            return stars;
        }

        set
        {
            Debug.Assert(value >= 0);
            stars = value;
            starText.text = stars.ToString();
        }
    }

    void Start () {
        starText = GetComponent<Text>();
        starText.text = stars.ToString();
    }
}
