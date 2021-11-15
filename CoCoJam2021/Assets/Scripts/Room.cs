using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : Interactable
{
    [SerializeField]
    private SpriteFader wall;
    [SerializeField]
    private SpriteFader door;
    [SerializeField]
    private GameObject corridorObjects;
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip doorOpen;
    [SerializeField]
    private AudioClip doorClose;
    [SerializeField]
    private AudioClip doorLocked;
    [SerializeField]
    private List<Collider2D> objects;
    [SerializeField]
    private List<Collider2D> traps;
    [SerializeField]
    private List<Boundary> activatedBoundaries;

    private bool isPlayerInside = false;

    public float transparency = 0.5f;

    private void Start()
	{
        foreach(var obj in objects)
        {
            obj.enabled = false; 
        }
        foreach(var obj in traps){
            obj.enabled = false; 
        }
	}
        
    private void Update()
    {
        DetectInteraction(KeyCode.E);

        if(door != null)
		{
            if (isPlayerInside)
            {
                if (isPlayerInRange)
                {
                    door.FadeTo(transparency);
                }
                else
                {
                    door.FadeTo(0);
                }
            }
            else
            {
                door.FadeTo(1);
            }
        }
    }

    override protected void TriggerEffect()
    {
        if (!isPlayerInside)
        {
            if(!isLocked){ //Is the room unlocked
                corridorObjects.SetActive(false);
                wall.FadeTo(0);

                foreach (var obj in objects)
                {
                    obj.enabled = true;
                }
                foreach (var obj in traps)
                {
                    obj.enabled = true;
                }

                foreach (var b in activatedBoundaries)
                {
                    b.gameObject.SetActive(true);
                }
                isPlayerInside = true;
                // Animation
                player.animator.SetBool("IsEntering", true);
                StartCoroutine(Wait());
                StartCoroutine(AudioWait());
            } else {
                audioSource.PlayOneShot(doorLocked);
                Debug.Log("Room is locked");
                // room is locked animation
                var dialog = new List<DialogLine>();
                dialog.Add(new DialogLine("It's locked...", true));
                dialog.Add(new DialogLine("Yeah, I can see that.", false));
                DialogueController.instance.WriteDialog(dialog);
            }
        }
        else
        {
            CloseRoom();
            if(doorOpen != null)
			{
                StartCoroutine(AudioWait());
            }
        }
    }

    public void CloseRoom(){
        corridorObjects.SetActive(true);
        wall.FadeTo(1);

        foreach (var obj in objects)
        {
            obj.enabled = false;
        }
        foreach (var obj in traps)
        {
            obj.enabled = false;
        }

        foreach (var b in activatedBoundaries)
        {
            b.gameObject.SetActive(false);
        }
        isPlayerInside = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        player.animator.SetBool("IsEntering", false);
    }

    IEnumerator AudioWait(){
        audioSource.PlayOneShot(doorOpen);
        yield return new WaitForSeconds(0.3f);
        audioSource.PlayOneShot(doorClose);
    }
}
