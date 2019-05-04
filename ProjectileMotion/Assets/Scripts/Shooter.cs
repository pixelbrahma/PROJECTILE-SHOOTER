using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] private Transform shotPrefab;
    private string powerText;
    public static Vector2 shotDirection;
    public static float power = 0f;
    public Transform shot;

    private void Start()
    {
        powerText = " ";
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shotDirection = mousePos - new Vector2(transform.position.x,transform.position.y).normalized;
        transform.up = shotDirection;
        if(Input.GetKey(KeyCode.Space))
        {
            power += 0.05f;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            shot = Instantiate(shotPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rbb = shot.gameObject.GetComponent<Rigidbody2D>();
            rbb.AddForce(Shooter.shotDirection * Shooter.power);
            power = 0f;
        }
        powerText = " POWER : " + power;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(50, 20, 200, 100), powerText);
        GUI.Label(new Rect(300, 20, 200, 100), ScoreCheck.text);
    }
}
