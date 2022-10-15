using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            if (!hit)
            {
                rb.velocity = new Vector2(0, 15);
                hit = true;
            }
            
            Die();
        }
    }

    private void Die()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        // Invoke("NextLevel", 2f);    // adds a 2 second delay
        // make death animation here
    }

    // move to next scene (restarting for now)
    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
