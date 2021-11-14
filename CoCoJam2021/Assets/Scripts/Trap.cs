using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    protected bool _isPlayerInRange = false;
    protected bool isCompleted = false;
    protected bool isStarted = false;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip start;
    [SerializeField]
    private AudioClip success;
    [SerializeField]
    private AudioClip fail;
    // Start is called before the first frame update

    protected void TrapSuccess(){
        Debug.Log("Trap completed");
        audioSource.PlayOneShot(success);
        gameObject.SetActive(false);
    }
    protected void TrapFail(){
        Debug.Log("Trap failed");
        audioSource.PlayOneShot(fail);
        GameController.instance.KillPlayer();
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log(collision.gameObject.tag + " Entered " + gameObject.name);
		if(collision.gameObject.tag == "Player" && !_isPlayerInRange)
		{
            audioSource.PlayOneShot(start);
            _isPlayerInRange = true;
		}
	}
}
