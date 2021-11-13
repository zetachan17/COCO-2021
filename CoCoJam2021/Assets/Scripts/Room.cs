using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private SpriteFader floor;
    private SpriteFader room;
    private bool _isPlayerInRange = true;

	private void Start()
	{
        room = GetComponent<SpriteFader>();
	}

	private void Update()
    {
        if (Input.GetKey(KeyCode.E) && _isPlayerInRange)
		{
            if(floor.isVisible)
			{
                floor.fadeOut();
                room.fadeIn();
            }
            else if (!floor.isVisible)
			{
                floor.fadeIn();
                room.fadeOut();
            }
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "player")
		{
            _isPlayerInRange = true;
		}
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            _isPlayerInRange = false;
        }
    }
}
