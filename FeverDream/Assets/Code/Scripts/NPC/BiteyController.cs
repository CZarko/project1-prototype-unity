using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteyController : MonoBehaviour {

    private Animator anim;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        StartCoroutine(ShootAfterDelay());
    }

    IEnumerator ShootAfterDelay() {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        anim.SetTrigger("Spit");
        StartCoroutine(ShootAfterDelay());
    }
}
