using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {

    public Animator anim;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        StartCoroutine(SpikeAutomation());
    }

    IEnumerator SpikeAutomation() {
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(Random.Range(2,5));
        anim.SetTrigger("Up");
        GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(Random.Range(2,5));
        StartCoroutine(SpikeAutomation());
        anim.SetTrigger("Down");
    }

}
