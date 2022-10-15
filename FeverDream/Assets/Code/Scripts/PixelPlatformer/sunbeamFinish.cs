using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sunbeamFinish : MonoBehaviour
{
    private GameObject lava;

    private bool levelCompleted = false;
    // Start is called before the first frame update
    void Start()
    {
        lava = GameObject.Find("Lava");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            lava.GetComponent<CameraScrolling>().enabled = false;
            levelCompleted = true;
            // Invoke("NextLevel", 2f);    // adds a 2 second delay
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
