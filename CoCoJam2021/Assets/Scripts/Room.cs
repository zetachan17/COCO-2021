using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : Interactable
{
    [SerializeField]
    private SpriteFader floor;
    [SerializeField]
    private List<Boundary> activatedBoundaries;

	override protected void TriggerEffect(){
        if (floor.isVisible)
        {
            floor.fadeOut();

            foreach(Boundary b in activatedBoundaries)
			{
                b.gameObject.SetActive(true);
			}
        }
        else if (!floor.isVisible)
        {
            floor.fadeIn();

            foreach (Boundary b in activatedBoundaries)
            {
                b.gameObject.SetActive(false);
            }
        }
    }
}
