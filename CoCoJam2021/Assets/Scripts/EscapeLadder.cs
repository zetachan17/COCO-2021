using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeLadder : Interactable
{
	private void Update()
	{
		DetectInteraction(KeyCode.E);
	}

	protected override void TriggerEffect()
    {
        GameController.instance.Win();
    }
}
