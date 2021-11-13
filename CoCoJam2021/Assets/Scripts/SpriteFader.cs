using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFader : MonoBehaviour
{
    public bool isVisible = true;
    [SerializeField]
    private float fadeSpeed = 1.0f;
    private SpriteRenderer renderer;

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
        renderer = GetComponent<SpriteRenderer>();
	}

	private void FixedUpdate()
    {
        // Fadeout
        if(!isVisible && renderer.color.a != 0.0f)
		{
            renderer.color = new Color
            (
                renderer.color.r,
                renderer.color.g,
                renderer.color.b,
                renderer.color.a - (Time.fixedDeltaTime * fadeSpeed)
            );

            if (renderer.color.a < 0.0f)
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0.0f);
        }

        // Fadein
        if (isVisible && renderer.color.a != 1.0f)
        {
            renderer.color = new Color
            (
                renderer.color.r,
                renderer.color.g,
                renderer.color.b,
                renderer.color.a + (Time.fixedDeltaTime * fadeSpeed)
            );

            if (renderer.color.a > 1.0f)
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1.0f);
        }
    }
}
