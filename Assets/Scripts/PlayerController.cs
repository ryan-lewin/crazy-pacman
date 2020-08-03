using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float speed = 10.0f;
    private float moveLimiter = 0;

    private int collected;
    public Text collectedScore;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        collected = 0;
        setCollectedText();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if(horizontal != 0 && vertical != 00)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pill"))
        {
            other.gameObject.SetActive (false);
            collected ++;
            setCollectedText();
        } else if(other.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("hit ghost");
            this.gameObject.SetActive(false);
        }
    }

    void setCollectedText()
    {
        collectedScore.text = "Game Score: " + collected.ToString();
    }
}
