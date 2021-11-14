using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObj : Interactable
{
    private GameController gameInstance;
    [SerializeField]
    private Interactable lockedInteractable;

    private void Update() {
        DetectInteraction(KeyCode.E);
    }

    override protected void TriggerEffect(){
        gameInstance.RemoveObject(this);
        gameObject.SetActive(false);
        Debug.Log("Picked up: " + gameObject.name);
        if(lockedInteractable)
        {
            lockedInteractable.Unlock();
        }
    }

    public void AssignGame(GameController gameInstance){
        this.gameInstance = gameInstance;
    }
}
