using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : Interactable
{
    private SpriteFader stairs;
    [SerializeField]
    private bool isForeground = true;
    [SerializeField]
    private float transparency = 0.5f;
	public int goesToFloor = 0;
    public Vector2 destination;

	private void Start()
	{
        stairs = GetComponent<SpriteFader>();
	}

	private void Update()
    {
        DetectInteraction(KeyCode.E);

        if (isForeground && isPlayerInRange)
        {
            stairs.FadeTo(transparency);
        }
        else
        {
            stairs.FadeTo(0);
        }
    }
    protected override void TriggerEffect()
	{
        Debug.Log("asked to change floor");
		GameController.instance.ChangeFloor(goesToFloor, destination);
	}
}
