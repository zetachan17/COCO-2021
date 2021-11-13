using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
	public bool isRightBoundary = true;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		Debug.Log("entered " + collision.gameObject.tag);
		if (collision.gameObject.tag == "Player")
		{
			PlayerController p = collision.gameObject.GetComponent<PlayerController>();
			if(isRightBoundary)
			{
				p.canMoveRight = false;
			}
			else
			{
				p.canMoveLeft = false;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		Debug.Log("entered " + collision.gameObject.tag);
		if (collision.gameObject.tag == "Player")
		{
			PlayerController p = collision.gameObject.GetComponent<PlayerController>();
			p.canMoveRight = true;
			p.canMoveLeft = true;
		}
	}
}
