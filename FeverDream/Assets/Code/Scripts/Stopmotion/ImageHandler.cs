using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHandler : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[27];
    public Image usedSprite;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            index++;
            usedSprite.sprite = sprites[index];
            if (index == 26)
            {
                index = 0;
                print("WIN");
            }
        }
    }
}
