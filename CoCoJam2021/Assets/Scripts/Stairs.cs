using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : Interactable
{
	public int goesToFloor = 0;
    public Vector2 destination;

	private void Update()
    {
        DetectInteraction(KeyCode.E);
    }
    protected override void TriggerEffect()
	{
		GameController.instance.ChangeFloor(goesToFloor, destination);
	}
}
