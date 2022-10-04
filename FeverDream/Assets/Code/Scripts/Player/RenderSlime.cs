using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSlime : MonoBehaviour
{
    float speed = 1f;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lr = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0, 0);
        if (transform.position.x < -1 || transform.position.x > 1)
            transform.position = new Vector3(transform.position.x * -1, 0, 0);
        if(Input.GetKeyDown("up") || Input.GetKeyDown("w"))
            Instantiate(bullet, new Vector3(transform.position.x * 10, 0,0), Quaternion.identity);
    }
} 
