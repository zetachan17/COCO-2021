using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObj : Interactable
{
    private GameController gameInstance;
    [SerializeField]
    private Room lockedRoom;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;

    private void Update() {
        DetectInteraction(KeyCode.E);
    }

    override protected void TriggerEffect(){
        gameInstance.RemoveObject(this);
        audioSource.PlayOneShot(audioClip);
        if(lockedRoom){
            lockedRoom.Unlock();
        }
        Debug.Log("Picked up: " + gameObject.name);
        gameObject.SetActive(false);
    }

    public void AssignGame(GameController gameInstance){
        this.gameInstance = gameInstance;
    }
}
