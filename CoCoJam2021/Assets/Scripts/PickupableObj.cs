using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObj : Interactable
{
    // Start is called before the first frame update
    void Start(){
        
    }

    private void Update() {
        DetectInteraction(KeyCode.E);
    }
    
    override protected void TriggerEffect(){
        Debug.Log("PickedUp");
    }
}
