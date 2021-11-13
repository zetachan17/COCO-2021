using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : Interactable
{
    [SerializeField]
    private SpriteFader floor;
    [SerializeField]
    private List<SpriteFader> objects;
    private SpriteFader room;
    

	private void Start()
	{
        room = GetComponent<SpriteFader>();
        room.fadeOut();
        foreach(SpriteFader obj in objects){
                obj.fadeOut(); 
            }
	}

    private void Update() {
        DetectInteraction(KeyCode.E);
    }

    override protected void TriggerEffect(){
        if(floor.isVisible){
            floor.fadeOut();
            room.fadeIn();
            foreach(SpriteFader obj in objects){
                obj.fadeIn();
            }
        }else if (!floor.isVisible){
            floor.fadeIn();
            foreach(SpriteFader obj in objects){
                obj.fadeOut();
            }
            room.fadeOut();
        } 
    }
}
