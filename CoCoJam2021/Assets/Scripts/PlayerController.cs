using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float  characterSpeed = 10.0f;
    [SerializeField]
    private float accelerationRate = 0.1f;
    private float acceleration = 0.1f;

    //[SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite idelSprite;

    private SpriteRenderer spriteRenderer;
    public Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        Vector3 direction = new Vector3(moveValue, 0.0f, 0.0f);
        direction = direction.normalized;

        if (direction != Vector3.zero)
        {
            if (direction.x > 0)
            {
                //spriteRenderer.sprite = rightSprite;
                spriteRenderer.flipX = false;
            }
            else if(direction.x < 0)
            {
                //spriteRenderer.sprite = rightSprite;
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            //spriteRenderer.sprite = idelSprite;
            spriteRenderer.flipX = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(moveValue * characterSpeed * acceleration * Time.deltaTime));

    }
}
