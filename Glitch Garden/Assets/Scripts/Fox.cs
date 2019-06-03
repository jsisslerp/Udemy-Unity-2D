using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.GetComponent<GraveStone>())
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        }
        else if (gameObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(gameObject);
        }
    }
}
