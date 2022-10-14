using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    //private SceneTracker tracker;

    void LoadNextScene() {
        if(SceneManager.GetActiveScene().buildIndex != 0) {
            GameObject.Find("canvas_eyelid").GetComponent<TransitionController>().ExitTransition();
        }
        StartCoroutine(DelaySceneLoad());
    }

    IEnumerator DelaySceneLoad() {
      yield return new WaitForSeconds(1f);
      SceneManager.LoadSceneAsync(Random.Range(1,7));
    }

    // Start is called before the first frame update
    void Start() {
        //tracker = GameObject.Find("SceneTracker").GetComponent<SceneTracker>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            LoadNextScene();
        }
    }

    /*public void LoadRandomAvailableScene() {
      if(tracker.RemainingScene()) {
        LoadScene(tracker.RandomScene());
      } else {
        tracker.Reset();
        LoadScene("Main");
      }
    }*/

    public void Quit() { Application.Quit(); }
}
