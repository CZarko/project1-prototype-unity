using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour {

    private Animator anim;

    // Start is called before the first frame update
    void Start() {
      anim = GetComponent<Animator>();
      anim.SetTrigger("Open");
    }

    // Update is called once per frame
    public void ExitTransition() {
        anim.SetTrigger("Close");
    }
}
