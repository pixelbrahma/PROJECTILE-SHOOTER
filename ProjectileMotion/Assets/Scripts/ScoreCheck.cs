using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCheck : MonoBehaviour {

    public static string text;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        text = " SCORED !! ";
        Invoke("Change", 5f);
        Destroy(collision.gameObject);
    }

    void Change()
    {
        text = "";
    }
}
