using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 13f;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Vector3.up * Time.deltaTime);
        if (transform.position.y > 9)
            Destroy(this.gameObject);
    }
}
