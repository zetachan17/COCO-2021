using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObj : Interactable
{
    private GameController gameInstance;
    [SerializeField]
    private Room lockedRoom;

    private void Update() {
        DetectInteraction(KeyCode.E);
    }

    override protected void TriggerEffect(){
        gameInstance.RemoveObject(this);
        gameObject.SetActive(false);
        Debug.Log("Picked up: " + gameObject.name);
        if(lockedRoom){
            lockedRoom.Unlock();
        }
    }

    public void AssignGame(GameController gameInstance){
        this.gameInstance = gameInstance;
    }
}
