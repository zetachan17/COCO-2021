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
    private List<Boundary> activatedBoundaries;

    private bool isPlayerInside = false;

    public float transparency = 0.5f;


    private void Start()
	{
        foreach(var obj in objects)
        {
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

	override protected void TriggerEffect(){
        if (!isPlayerInside)
        {
            foreach (var obj in objects)
            {
                obj.enabled = true;
            }

            foreach (var b in activatedBoundaries)
			{
                b.gameObject.SetActive(true);
			}
        }
        else
        {
            foreach (var obj in objects)
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
}
