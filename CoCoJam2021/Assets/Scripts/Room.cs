using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private SpriteFader floor;
    private SpriteFader room;
    private bool _isPlayerInRange = false;

	private void Start()
	{
        room = GetComponent<SpriteFader>();
        room.fadeOut();
	}

	private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isPlayerInRange)
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
        Debug.Log("Entered " + collision.gameObject.tag);
		if(collision.gameObject.tag == "Player")
		{
            _isPlayerInRange = true;
		}
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            _isPlayerInRange = false;
        }
    }
}
