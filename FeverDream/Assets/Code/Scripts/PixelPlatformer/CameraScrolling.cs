using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrolling : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 1f;
    private float dirY = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 22)
        {
            transform.position += new Vector3(0, dirY * moveSpeed * Time.deltaTime, 0);
        }
    }
}
