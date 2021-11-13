using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    private int index = 0;

    [SerializeField] private float dialogueSpeed;
    [SerializeField] private Animator dialogueAnimator;
    private bool startDialogue = true;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (startDialogue)
            {
                dialogueAnimator.SetTrigger("Enter");
                startDialogue = false;
            }
            else
            {
                NextSentence();
            }
        }
    }

    IEnumerator WriteSentence()
    {
        foreach(char character in sentences[index].ToCharArray())
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        index++;
    }

    void NextSentence()
    {
        if (index <= sentences.Length - 1)
        {
            dialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            dialogueText.text = "";
            dialogueAnimator.SetTrigger("Exit");
            index = 0;
            startDialogue = true;
        }
    }
}
