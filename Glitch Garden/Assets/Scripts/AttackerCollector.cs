using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerCollector : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LivesDisplay>().Lives--;
        Destroy(collision.gameObject);
    }
}
