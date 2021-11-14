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
    private List<Collider2D> objects;
    [SerializeField]
    private List<Collider2D> traps;
    [SerializeField]
    private List<Boundary> activatedBoundaries;
    [SerializeField]
    private bool isLocked = false;

    private bool isPlayerInside = false;

    public float transparency = 0.5f;

    [SerializeField]
    private PlayerController player;

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
            }else{
                Debug.Log("Room is locked");
                // room is locked animation
            }
        }
        else
        {
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
        //isPlayerInside = !isPlayerInside;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        player.animator.SetBool("IsEntering", false);
    }

    public void Unlock(){
        isLocked = false;
    }
}
