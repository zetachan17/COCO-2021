using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float  characterSpeed = 10.0f;
    [SerializeField]
    private float accelerationRate = 0.1f;
    private float acceleration = 0.1f;

    [HideInInspector]
    public bool canMoveLeft = true;
    public bool canMoveRight = true;

    // Update is called once per frame
    void Update()
    {
        float moveValue = Input.GetAxis("Horizontal");
        if (moveValue != 0 &&
            ((canMoveLeft && moveValue < 0) ||
            (canMoveRight && moveValue > 0)))
        {
            if (acceleration <= 1.0f)
            {
                acceleration += accelerationRate;
            }
            transform.Translate(moveValue*characterSpeed*acceleration*Time.deltaTime,0,0);
        }
        else
        {
            acceleration = 0;
        }
    }
}
