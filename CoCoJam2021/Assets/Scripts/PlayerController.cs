using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance = null;

    [SerializeField]
    private float  characterSpeed = 10.0f;
    [SerializeField]
    private float accelerationRate = 0.1f;
    private float acceleration = 0.1f;

    [HideInInspector]
    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canCrouch = true;

    private SpriteRenderer spriteRenderer;
    public Animator animator;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip deathAudio;
    [SerializeField]
    private float timeBetweensteps = 0.1f;
    private float timer = 0.0f;
    private Rigidbody2D rb;

	private void Awake()
	{
		if(instance == null)
		{
            instance = this;
		}
        else
		{
            Destroy(gameObject);
		}
	}

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

            animator.SetBool("IsWalking", true);


            timer += Time.deltaTime;
            if(timer >= timeBetweensteps){
                audioSource.Play();
                timer = 0.0f;
            }
            
        }
        else
        {
            acceleration = 0;
            timer = 0.0f;
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.S) && canCrouch)
        {
            animator.SetBool("IsCrouching", true);
            StartCoroutine(Wait());
        }

    }

    public void Die(){
        animator.SetTrigger("IsDead");
        rb.constraints = RigidbodyConstraints2D.None;
        audioSource.PlayOneShot(deathAudio);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("IsCrouching", false);
    }

    public void StopFor(float time)
	{
        StartCoroutine(stopFor(time));
	}

    private IEnumerator stopFor(float time)
	{
        Stop();
        yield return new WaitForSeconds(time);
        UnStop();
	}

	public void Stop()
	{
        canMoveLeft = false;
        canMoveRight = false;
        canCrouch = false;
    }

    public void UnStop()
    {
        canCrouch = true;
        canMoveLeft = true;
        canMoveRight = true;
    }
}
