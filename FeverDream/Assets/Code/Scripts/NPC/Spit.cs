using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : StateMachineBehaviour {
    public GameObject arrow;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject clone = Instantiate(arrow);
    }

}
