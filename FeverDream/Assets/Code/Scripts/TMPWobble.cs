using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPWobble : MonoBehaviour {
    private TMP_Text textMesh;
    private Mesh mesh;
    private Vector3[] vertices;
    private Color[] colors;
    public bool slimed = false;
    [Range(0f,2f)]
    public float slimeMultiplier = 1f;
    [Range(0f,2f)]
    public float wobbleMultiplier = 1f;

    // Start is called before the first frame update
    void Start() {
        textMesh = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update() {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;
        colors = mesh.colors;
        for(int i = 0; i < textMesh.textInfo.characterCount; ++i) {
            TMP_CharacterInfo c = textMesh.textInfo.characterInfo[i];

            int index = c.vertexIndex;

            if(slimed) { // green text effect
                colors[index] = Color.Lerp(Color.white, Color.green, Mathf.PingPong(slimeMultiplier*Time.time+vertices[index].y*0.01f, 1f));
                colors[index+1] = Color.Lerp(Color.white, Color.green, Mathf.PingPong(slimeMultiplier*Time.time+vertices[index+1].y*0.01f, 1f));
                colors[index+2] = Color.Lerp(Color.white, Color.green, Mathf.PingPong(slimeMultiplier*Time.time+vertices[index+2].y*0.01f, 1f));
                colors[index+3] = Color.Lerp(Color.white, Color.green, Mathf.PingPong(slimeMultiplier*Time.time+vertices[index+3].y*0.01f, 1f));
            }

            Vector3 offset = Wobble(Time.time + i);
            vertices[index] += offset;
            vertices[index+1] += offset;
            vertices[index+2] += offset;
            vertices[index+3] += offset;
        }
        mesh.vertices = vertices;
        mesh.colors = colors;
        textMesh.canvasRenderer.SetMesh(mesh);
    }

    Vector2 Wobble(float time) {
        return new Vector2(Mathf.Sin(time*3.3f*wobbleMultiplier), Mathf.Cos(time*2.5f*wobbleMultiplier));
    }
}
