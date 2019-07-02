using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBoxPrompt : MonoBehaviour
{
    public GameObject textBox; 
    public GameObject textDialogue;

    [Header("Dialogue")]
    public bool playOnlyOnce = false;
    public float displayDialogueTimer = 3f;
    
    [Space]
    [TextArea]
    public string dialogueText;

    //will display text input and then start timer for duration of text.
    private void OnTriggerEnter(Collider other)
    {
        if (textBox == null || textDialogue == null)
        {
            Debug.Log("Check game object - " + gameObject.name + " in script DialogueBoxPrompt for public variables");
        }
        else
        {
            textBox.SetActive(true);
            textDialogue.GetComponent<TextMeshProUGUI>().text = dialogueText;
            StartCoroutine(DisplayDuration());
        }
    }

    //After specified time, the text will fade out
    IEnumerator DisplayDuration()
    {
        yield return new WaitForSeconds(displayDialogueTimer);

        if (textBox != null && textDialogue != null)
        {
            textDialogue.GetComponent<Animator>().SetTrigger("Fade");
            textBox.GetComponent<Animator>().SetTrigger("Fade");
        }

        //disables dialogue box if the box is only used once
        if (playOnlyOnce == true)
        {
            gameObject.SetActive(false);
        }
    }
}
