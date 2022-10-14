using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossDungeonController : MonoBehaviour {

    [SerializeField]
    private bool movingPlayer = false, movingCamera = false;

    void Update() {
      if(Input.GetKeyDown(KeyCode.W) && transform.position.y < 23f && (!movingPlayer && !movingCamera)) {
        movingPlayer = true;
        StartCoroutine(MoveUp(this.gameObject));
      }
    }

    IEnumerator MoveUp(GameObject obj) {
      float timer = 0f;
      Vector3 target = new Vector3(obj.transform.position.x, obj.transform.position.y + 8.5f, obj.transform.position.z);
      while(true) {
        timer += Time.deltaTime;
        obj.transform.position = Vector3.Lerp(obj.transform.position, target, (float)(timer));
        if(obj.transform.position.y >= target.y) {
          if(movingPlayer && !movingCamera) {
            movingPlayer = false; movingCamera = true;
            StartCoroutine(MoveUp(Camera.main.gameObject));
          } else { movingCamera = false; }
          yield break;
        }
        yield return null;
      }
    }

    private void OnCollisionEnter(Collision collision) {
        Destroy(this.gameObject);
    }
}
