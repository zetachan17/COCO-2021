using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : Interactable
{
    [SerializeField]
    private SpriteFader floor;
    [SerializeField]
    private List<Collider2D> objects;
    [SerializeField]
    private List<Collider2D> traps;
    [SerializeField]
    private List<Boundary> activatedBoundaries;

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
                floor.FadeTo(transparency);
            }
            else
			{
                floor.FadeTo(0);
            }
        }
        else
        {
            floor.FadeTo(1);
        }
    }

    override protected void TriggerEffect()
    {
        if (!isPlayerInside)
        {
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

            // Animation
            player.animator.SetBool("IsEntering", true);
            StartCoroutine(Wait());
        }
        else
        {
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
        }
        isPlayerInside = !isPlayerInside;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        player.animator.SetBool("IsEntering", false);
    }
}
