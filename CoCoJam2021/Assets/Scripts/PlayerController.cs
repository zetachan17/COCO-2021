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

    [HideInInspector]
    public bool canMoveLeft = true;
    public bool canMoveRight = true;

    private SpriteRenderer spriteRenderer;
    public Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

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

            if(moveValue < 0)
			{
                spriteRenderer.flipX = true;
            }
            else
			{
                spriteRenderer.flipX = false;
            }

            transform.Translate(moveValue*characterSpeed*acceleration*Time.deltaTime,0,0);
            animator.SetFloat("Speed", Mathf.Abs(moveValue * characterSpeed * acceleration * Time.deltaTime));
        }
        else
        {
            acceleration = 0;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            animator.SetTrigger("IsDead");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("IsCrouching", true);
            StartCoroutine(Wait());
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("IsCrouching", false);
    }
}
