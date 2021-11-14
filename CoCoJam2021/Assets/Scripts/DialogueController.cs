using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [HideInInspector]
    public static DialogueController instance = null;

    public TextMeshProUGUI dialogueText;
    [SerializeField]
    public List<DialogLine> dialog;

    [SerializeField]
    private float dialogueSpeed = 0.1f;
    [SerializeField]
    private float dialogueTimer = 0.5f;
    [SerializeField]
    private float fadeTimer = 1.0f;

    [SerializeField]
    private Animator dialogueAnimator;
    [SerializeField]
    private Image currentDialogBox;
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
    private IEnumerator currentDialogBoxAnimation = null;

    private bool dialogInSession = false;

    [SerializeField]
    private AudioSource audioSource;

    private void Awake() {
        if(instance == null)
		{
            instance = this;
		}
        else
		{
            Destroy(gameObject);
		}
    }

	// Update is called once per frame
	//void Update()
 //   {
 //       // Make sure to follow the camera
 //       float camPos = Camera.main.transform.position.x;
 //       if(transform.position.x != camPos)
	//	{
 //           transform.position = new Vector3(camPos, transform.position.y, transform.position.z);
	//	}
 //   }

    public void WriteDialog(List<DialogLine> dialog)
	{
        if(!dialogInSession)
		{
            foreach(DialogLine dl in dialog)
			{
                this.dialog.Add(new DialogLine(dl.line, dl.isCat));
            }
            StartCoroutine(writeDialog());
        }
	}

    IEnumerator writeDialog()
    {
        
        AnimateCharacter(dialog[0].isCat);

        dialogueAnimator.SetTrigger("Enter");
        yield return new WaitForSeconds(fadeTimer);
        
        while (dialog.Count != 0) {
            AnimateCharacter(dialog[0].isCat);
            audioSource.Play();
            foreach (char character in dialog[0].line.ToCharArray())
            {
                dialogueText.text += character;
                yield return new WaitForSeconds(dialogueSpeed);
            }
            audioSource.Stop();
            dialog.RemoveAt(0);

            yield return new WaitForSeconds(dialogueTimer);
            dialogueText.text = "";
        }

        StopCoroutine(currentDialogBoxAnimation);
        dialogueText.text = "";
        dialogueAnimator.SetTrigger("Exit");
        yield return new WaitForSeconds(fadeTimer);

        dialogInSession = false;
    }

    private void AnimateCharacter(bool isCat)
	{
        if (currentDialogBoxAnimation != null)
            StopCoroutine(currentDialogBoxAnimation);

        if (isCat)
            currentDialogBoxAnimation = animateCat();
        else
            currentDialogBoxAnimation = animateGirl();

        StartCoroutine(currentDialogBoxAnimation);
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
