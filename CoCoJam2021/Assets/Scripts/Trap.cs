using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    protected bool _isPlayerInRange = false;
    protected bool isCompleted = false;
    protected bool isStarted = false;
    // Start is called before the first frame update

    protected void TrapSuccess(){
        Debug.Log("Trap completed");
    }
    protected void TrapFail(){
        Debug.Log("Trap failed");
    }
    private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log(collision.gameObject.tag + " Entered " + gameObject.name);
		if(collision.gameObject.tag == "Player")
		{
            _isPlayerInRange = true;
		}
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag + " Exited " + gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            _isPlayerInRange = false;
        }
    }
}
