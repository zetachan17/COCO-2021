using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFader : MonoBehaviour
{
    public bool isVisible = true;
    [SerializeField]
    private float fadeSpeed = 1.0f;
    private SpriteRenderer _renderer;
    private BoxCollider2D _collider;

    public void fadeOut()
	{
        isVisible = false;
        if(_collider){
            _collider.enabled = false;
        }
	}

    public void fadeIn()
	{
        isVisible = true;
        if(_collider){
            _collider.enabled = true;
        }
	}

	private void Start()
	{
        _renderer = GetComponent<SpriteRenderer>();
        if(gameObject.tag == "Pickupable")_collider = GetComponent<BoxCollider2D>();
	}

	private void FixedUpdate()
    {
        // Fadeout
        if(!isVisible && _renderer.color.a != 0.0f)
		{
            _renderer.color = new Color
            (
                _renderer.color.r, 
                _renderer.color.g, 
                _renderer.color.b, 
                _renderer.color.a - (Time.fixedDeltaTime * fadeSpeed)
            );

            if (_renderer.color.a < 0.0f)
                _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 0.0f);
        }

        // Fadein
        if (isVisible && _renderer.color.a != 1.0f)
        {
            _renderer.color = new Color
            (
                _renderer.color.r,
                _renderer.color.g,
                _renderer.color.b,
                _renderer.color.a + (Time.fixedDeltaTime * fadeSpeed)
            );

            if (_renderer.color.a > 1.0f)
                _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 1.0f);
        }
    }
}
