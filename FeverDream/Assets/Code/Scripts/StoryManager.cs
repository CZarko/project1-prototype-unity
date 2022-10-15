using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class StoryManager : MonoBehaviour {

    [Header("Story UI")]
    [SerializeField] TextMeshProUGUI tmp;
    public GameObject choicePanel;
    public GameObject button;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private Story story;

    private void Start() {
      story = new Story(inkJSON.text);
      DoStory();
    }

    private void Update() {

    }

    private void DoStory() {
      if(story.canContinue) {
        tmp.text = story.Continue();
        if(story.currentChoices.Count != 0) {
          StartCoroutine(HandleChoices());
        } else { StartCoroutine(DelayContinue()); }
      } else {
        Debug.Log("Leave scene here.");
      }
    }

    IEnumerator DelayContinue() {
      yield return new WaitForSeconds(1f);
      yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
      DoStory();
    }

    IEnumerator HandleChoices() {
      string chosen = null;

      foreach(Choice c in story.currentChoices) {
        GameObject btn = Instantiate(button, choicePanel.transform);
        btn.transform.position = new Vector3(btn.transform.position.x, btn.transform.position.y + 50*c.index, btn.transform.position.z);
        btn.transform.GetChild(0).GetComponent<TMP_Text>().text = c.text;
        btn.GetComponent<Button>().onClick.AddListener(delegate {chosen = HandleChoicePick(c);});
      }
      choicePanel.SetActive(true);
      yield return new WaitUntil(() => {return chosen != null;});
      Debug.Log(chosen);

      choicePanel.SetActive(false);
      for(int i = 0; i < choicePanel.transform.childCount; ++i) {
        Destroy(choicePanel.transform.GetChild(i).gameObject);
      }
      DoStory();
    }

    string HandleChoicePick(Choice choice) {
        story.ChooseChoiceIndex(choice.index);
        return "done";
    }

}
