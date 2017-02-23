using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float jumpSpeed;
    public Text scoreCount;
    public Text gameOver;

    bool grounded = false;
    private int score;
    private Rigidbody2D playerbody;

	// Use this for initialization
	void Start () {
        playerbody = GetComponent<Rigidbody2D> ();
        score = 0;
        updateScore();
        gameOver.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveX = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveX, 0);
        playerbody.AddForce(movement*speed);
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                playerbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                grounded = false;
            }                       
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            score = score+1;
            updateScore();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

    void updateScore()
    {
        scoreCount.text = score.ToString() + " coins collected!";
        if(score == 7)
        {
            gameOver.text = "You have beaten the video game sir!";
        }
    }
}
