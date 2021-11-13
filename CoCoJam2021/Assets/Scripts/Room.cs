using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : Interactable
{
    [SerializeField]
    private SpriteFader floor;
    [SerializeField]
    private List<SpriteFader> objects;
    [SerializeField]
    private List<SpriteFader> traps;
    private SpriteFader room;
    

	private void Start()
	{
        room = GetComponent<SpriteFader>();
        room.fadeOut();
        foreach(SpriteFader obj in objects){
            obj.fadeOut(); 
        }
        foreach(SpriteFader obj in traps){
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
            foreach(SpriteFader obj in traps){
                obj.fadeIn(); 
            }
        }else if (!floor.isVisible){
            floor.fadeIn();
            foreach(SpriteFader obj in objects){
                obj.fadeOut();
            }
            foreach(SpriteFader obj in traps){
                obj.fadeOut(); 
            }
            room.fadeOut();
        } 
    }
}
