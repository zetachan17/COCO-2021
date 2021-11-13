using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool _isPlayerInRange = false;

    // Implement this in child update function
    protected void DetectInteraction(KeyCode key){
        if (Input.GetKeyDown(key) && _isPlayerInRange){
            TriggerEffect();
        }
    }

    // Place effect of activating a trigger here
    protected virtual void TriggerEffect(){}

    private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log(collision.gameObject.tag + " Entered " + gameObject.name);
		if(collision.gameObject.tag == "Player")
		{
            _isPlayerInRange = true;
		}
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag + " Exited " + gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            _isPlayerInRange = false;
        }
    }
}
