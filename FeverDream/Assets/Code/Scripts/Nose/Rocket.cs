using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private float rotateSpeed = 180f;
    private float rocketSpeed = 40f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Rotate(new Vector3(0, -1 * rotateSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal"), 0));
        //GetComponent<Rigidbody>().AddForce
        //transform.Translate(new Vector3(-1 * Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z),Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), 0) * Time.deltaTime);
        //print(Mathf.Cos(transform.eulerAngles.z * Mathf.PI / 180));
        transform.Translate(Vector3.forward * Time.deltaTime * rocketSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
