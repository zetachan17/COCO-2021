using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    [SerializeField]
    public List<DialogLine> sentences;

    [SerializeField]
    private float dialogueSpeed = 0.1f;
    [SerializeField]
    private float dialogueTimer = 0.5f;

    [SerializeField]
    private Animator dialogueAnimator;
    [SerializeField]
    private SpriteRenderer currentDialogBox;
    [SerializeField]
    private Sprite catClosed;
    [SerializeField]
    private Sprite catOpened;
    [SerializeField]
    private Sprite girlClosed;
    [SerializeField]
    private Sprite girlOpened;
    [SerializeField]
    private float animationDelay;


    // Update is called once per frame
    void Update()
    {
        // Make sure to follow the camera
        float camPos = Camera.main.transform.position.x;
        if(transform.position.x != camPos)
		{
            transform.position = new Vector3(camPos, transform.position.y, transform.position.z);
		}
    }

    IEnumerator WriteSentence()
    {
        foreach(char character in sentences[0].line.ToCharArray())
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        sentences.RemoveAt(0);
        yield return new WaitForSeconds(dialogueTimer);
    }

    void NextSentence()
    {
        if (sentences.Count != 0)
        {
            dialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            dialogueText.text = "";
            dialogueAnimator.SetTrigger("Exit");
        }
    }

    private IEnumerator animateCat()
	{
        while(true)
		{
            currentDialogBox.sprite = catClosed;
            yield return new WaitForSeconds(animationDelay);
            currentDialogBox.sprite = catOpened;
            yield return new WaitForSeconds(animationDelay);
        }
	}

    private IEnumerator animateGirl()
    {
        while (true)
        {
            currentDialogBox.sprite = girlClosed;
            yield return new WaitForSeconds(animationDelay);
            currentDialogBox.sprite = girlOpened;
            yield return new WaitForSeconds(animationDelay);
        }
    }
}
