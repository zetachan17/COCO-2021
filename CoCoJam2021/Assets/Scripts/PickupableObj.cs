using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObj : Interactable
{
    private GameController gameInstance;
    [SerializeField]
    protected Interactable lockedInteractable;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;

    private void Update() {
        DetectInteraction(KeyCode.E);
    }

    override protected void TriggerEffect() {
        gameInstance.RemoveObject(this);
        gameObject.SetActive(false);
        Debug.Log("Picked up: " + gameObject.name);
        if(lockedInteractable)
        {
            lockedInteractable.Unlock();
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void AssignGame(GameController gameInstance){
        this.gameInstance = gameInstance;
    }
}
