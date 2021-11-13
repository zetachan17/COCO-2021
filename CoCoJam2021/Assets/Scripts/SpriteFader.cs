using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFader : MonoBehaviour
{
    public bool isVisible = true;
    [SerializeField]
    private float fadeSpeed = 1.0f;
    private SpriteRenderer _renderer;

    public void fadeOut()
	{
        isVisible = false;
	}

    public void fadeIn()
	{
        isVisible = true;
	}

	private void Start()
	{
        _renderer = GetComponent<SpriteRenderer>();
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
