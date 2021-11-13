using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObj : Interactable
{
    private SpriteFader objSprite;
    private GameController gameInstance;
    // Start is called before the first frame update
    void Start(){
        objSprite = GetComponent<SpriteFader>();
    }

    private void Update() {
        DetectInteraction(KeyCode.E);
    }

    override protected void TriggerEffect(){
        gameInstance.RemoveObject(this);
        gameObject.SetActive(false);
        Debug.Log("Picked up: " + gameObject.name);
    }
    public void AssignGame(GameController gameInstance){
        this.gameInstance = gameInstance;
    }
}
