using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : Interactable
{
    [SerializeField]
    private SpriteFader floor;
    private SpriteFader room;

    private GameObject player;

    private void Start()
	{
        room = GetComponent<SpriteFader>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    override protected void TriggerEffect(){
        if (floor.isVisible)
        {
            floor.fadeOut();
            room.fadeIn();
            player.GetComponent<PlayerController>().animator.SetBool("IsEntering", true);
            
            StartCoroutine(Wait());
        }
        else if (!floor.isVisible)
        {
            floor.fadeIn();
            room.fadeOut();
            player.GetComponent<PlayerController>().animator.SetBool("IsEntering", false);
            StartCoroutine(Wait());
        } 
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<PlayerController>().animator.SetBool("IsEntering", false);
    }
}
