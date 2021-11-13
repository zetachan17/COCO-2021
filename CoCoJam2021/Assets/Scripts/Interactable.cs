using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool isPlayerInRange = false;

    // Implement this in child update function
    protected void DetectInteraction(KeyCode key){
        if (Input.GetKeyDown(key) && isPlayerInRange){
            TriggerEffect();
        }
    }

    // Place effect of activating a trigger here
    protected virtual void TriggerEffect(){}

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
            isPlayerInRange = true;
		}
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }
}
