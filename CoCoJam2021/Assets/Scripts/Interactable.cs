using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool _isPlayerInRange = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isPlayerInRange){
            TriggerEffect();
        }
    }

    // Place effect of activating a trigger here
    protected virtual void TriggerEffect(){}
    
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
