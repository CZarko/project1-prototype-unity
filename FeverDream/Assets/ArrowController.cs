using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    private float started;
    private Vector3 target;

    void Start() {
        started = Time.deltaTime;
        target = this.transform.position;
        target.x = -12f;
    }

    // Update is called once per frame
    void Update() {
        if(transform.position.x > -11f) {
            transform.position = Vector3.Lerp(transform.position, target, started);
        } else {
          Destroy(this.gameObject);
        }
    }

}
