using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossDungeonController : MonoBehaviour {

    [SerializeField]
    private bool movingPlayer = false, movingCamera = false;

    void Update() {
      if(Input.GetKeyDown(KeyCode.A) && (!movingPlayer && !movingCamera)) {
        movingPlayer = true;
        StartCoroutine(MoveUp(this.gameObject, 0.01f));
      }
    }

    IEnumerator MoveUp(GameObject obj, float speedMult) {
      float timer = 0f;
      Vector3 target = new Vector3(obj.transform.position.x, obj.transform.position.y + 8.5f, obj.transform.position.z);
      while(true) {
        timer += Time.deltaTime;
        obj.transform.position = Vector3.Lerp(obj.transform.position, target, timer);
        if(obj.transform.position.y >= target.y) {
          if(movingPlayer && !movingCamera) {
            movingPlayer = false; movingCamera = true;
            StartCoroutine(MoveUp(Camera.main.gameObject, 0.001f));
          } else { movingCamera = false; }
          yield break;
        }
        yield return null;
      }
    }
}
