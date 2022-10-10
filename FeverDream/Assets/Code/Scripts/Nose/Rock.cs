using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private float rotatex;
    private float rotatey;
    private float rotatez;
    // Start is called before the first frame update
    void Start()
    {
        rotatex = Random.Range(-10, 10);
        rotatey = Random.Range(-10, 10);
        rotatez = Random.Range(-10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotatex,rotatey,rotatez) * Time.deltaTime);
    }
}
