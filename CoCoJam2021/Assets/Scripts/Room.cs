using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : Interactable
{
    [SerializeField]
    private SpriteFader floor;
    [SerializeField]
    private List<SpriteFader> objects;
    [SerializeField]
    private List<Boundary> activatedBoundaries;


    private void Start()
	{
        foreach(SpriteFader obj in objects)
        {
            obj.fadeOut(); 
        }
	}
        
    private void Update()
    {
        DetectInteraction(KeyCode.E);
    }

	override protected void TriggerEffect(){
        if (floor.isVisible)
        {
            floor.fadeOut();

            foreach(SpriteFader obj in objects)
            {
                obj.fadeIn();
            }

            foreach(Boundary b in activatedBoundaries)
			{
                b.gameObject.SetActive(true);
			}
        }
        else if (!floor.isVisible)
        {
            floor.fadeIn();

            foreach(SpriteFader obj in objects)
            {
                obj.fadeOut();
            }

            foreach (Boundary b in activatedBoundaries)
            {
                b.gameObject.SetActive(false);
            }
        }
    }
}
