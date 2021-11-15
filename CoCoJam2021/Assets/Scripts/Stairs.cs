using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : Interactable
{
	public int goesToFloor = 0;
    public Vector2 destination;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;

	private void Update()
    {
        DetectInteraction(KeyCode.E);
    }
    protected override void TriggerEffect()
    {
        if (!isLocked)
        {
            GameController.instance.ChangeFloor(goesToFloor, destination);
            audioSource.PlayOneShot(audioClip, 0.5f);
        }
    }
}
