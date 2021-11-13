using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 2.0f;

    private bool _isVisible = true;
    private SpriteRenderer _renderer;

    public void fadeOut()
	{
        _isVisible = false;
	}

    public void fadeIn()
	{
        _isVisible = true;
	}

	private void Start()
	{
        _renderer = GetComponent<SpriteRenderer>();
	}

	private void FixedUpdate()
    {
        if(!_isVisible && _renderer.color.a != 0.0f)
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

        //TODO: add the fadeIn
    }
}
