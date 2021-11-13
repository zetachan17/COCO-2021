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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveValue = Input.GetAxis("Horizontal");
        if(moveValue != 0){
            if(acceleration <= 1.0f){
                acceleration += accelerationRate;
            }
            transform.Translate(moveValue*characterSpeed*acceleration*Time.deltaTime,0,0);
        }else{
            acceleration = 0;
        }
    }

    void MovePlayer(float moveValue){
        
    }
}
