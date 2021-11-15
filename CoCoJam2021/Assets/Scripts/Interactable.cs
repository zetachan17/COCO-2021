using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    protected bool isLocked = false;

    [SerializeField]
    private List<DialogLine> dialog;

    [SerializeField]
    private List<DialogLine> lockedDialog;

    protected bool isPlayerInRange = false;

    // Implement this in child update function
    protected void DetectInteraction(KeyCode key)
    {
        if (Input.GetKeyDown(key) && isPlayerInRange)
        {
            TriggerEffect();
            if (isLocked)
            {
                DialogueController.instance.WriteDialog(lockedDialog);
            }

        }
    }

    // Place effect of activating a trigger here
    protected virtual void TriggerEffect() {}

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
            isPlayerInRange = true;
            
            DialogueController.instance.WriteDialog(dialog);
        }
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }

    public void Unlock()
    {
        isLocked = false;
    }
}
