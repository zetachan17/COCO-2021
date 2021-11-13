using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private Floor floor;

    void Update()
    {
        if(Input.GetKey(KeyCode.E))
		{
            floor.fadeOut();
		}
    }
}
