using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : Interactable
{
    [SerializeField]
    private SpriteFader floor;
    private SpriteFader room;

	private void Start()
	{
        room = GetComponent<SpriteFader>();
	}

    override protected void TriggerEffect(){
        if(floor.isVisible){
            floor.fadeOut();
            room.fadeIn();
        }else if (!floor.isVisible){
            floor.fadeIn();
            room.fadeOut();
        } 
    }
}
