using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicController : MonoBehaviour {

    private float prevX;

    // Update is called once per frame
    void Update() {
        float xpos = Mathf.PingPong(Time.time, 14)-7;

        Physics.SyncTransforms();
        Move(xpos);

        this.GetComponent<SpriteRenderer>().flipX = (xpos < prevX) ? false : true;
        prevX = xpos;
    }
    void Move(float xpos) {
      this.transform.position = new Vector3(xpos, transform.position.y, transform.position.z);
    }
}
