using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private Floor floor;
    private bool _isPlayerInRange = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && _isPlayerInRange)
		{
            if(floor.isVisible)
                floor.fadeOut();
            else if (!floor.isVisible)
                floor.fadeIn();
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
