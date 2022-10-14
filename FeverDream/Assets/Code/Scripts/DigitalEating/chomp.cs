using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chomp : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;

    public bool canChomp = true;

    private enum CharacterState {idle, chomp}

    private GameObject burger;
    private int counter = 0;
    private bool trigger = false;
    public Sprite bite1;
    public Sprite bite2;
    public Sprite bite3;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        burger = GameObject.Find("burger");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && canChomp)
        {
            canChomp = false;
            Invoke("EndChomp", 0.5f);
        }
        
        UpdateAnimationState();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "burger" && !canChomp)
        {
            if (counter == 0)
            {
                burger.GetComponent<SpriteRenderer>().sprite = bite1;
            }
            else if (counter == 1)
            {
                burger.GetComponent<SpriteRenderer>().sprite = bite2;
            }
            else if (counter == 2)
            {
                burger.GetComponent<SpriteRenderer>().sprite = bite3;
            }
            else if (counter == 3)
            {
                burger.GetComponent<SpriteRenderer>().enabled = false;
            }
            trigger = true;
        }

    }

    private void UpdateAnimationState()
    {
        CharacterState state;
        
        if (!canChomp)
        {
            state = CharacterState.chomp;
        }
        else
        {
            state = CharacterState.idle;
        }

        anim.SetInteger("state", (int)state);
    }

    private void EndChomp()
    {
        canChomp = true;
        if (trigger == true)
        {
            counter++;
            trigger = false;
        }
    }
}
