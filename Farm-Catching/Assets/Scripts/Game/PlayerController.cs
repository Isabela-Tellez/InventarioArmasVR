using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] HighscoreTable highscoreTable;
    public GameObject HighScoreTable;

    public float speed = 5f;

    private Rigidbody2D rb;
    public float jumpHeight;
    private bool isGround = true;

    private Animator anim;

    public Vector3 GetPosition() { return transform.position; }
    void Start()
    { 
        HighScoreTable.SetActive(false);
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Time.timeScale = 0f;
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            Time.timeScale = 1f;
        }

        transform.Translate(new Vector2(1f, 0f) * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            Jump();
            anim.SetBool("Jump", true);
            isGround = false;
        }

        if (transform.position.y <= -30f)
        {
            this.gameObject.SetActive(false);
            Die();
        }
    }

    void Jump()
    {
        Vector2 velocity = rb.velocity;
        velocity.y = jumpHeight;
        rb.velocity = velocity;
    }

    public void Die()
    {
        FindObjectOfType<GameManager>().isGameActive = false;
        int finalscore = LevelGenerator.GetlevelPartsSpawned();
        HighscoreNameWindow.Show(finalscore, (string name) => 
        {
            HighscoreTable.AddHighscoreEntry(finalscore, name);
            HighScoreTable.SetActive(true);
        });
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGround = true;
            anim.SetBool("Jump", false);
        }

        if (other.transform.CompareTag("Trap"))
        {
            FindObjectOfType<GameManager>().isGameActive = false;
            this.gameObject.SetActive(false);
            Die();
        }
    }
}
