using System.Collections;
using UnityEngine;

public class SpriteFader : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 1.0f;
    private SpriteRenderer _renderer;

    public IEnumerator currentFade = null;
    private float goingForAlpha = 0;

	private void Start()
	{
        _renderer = GetComponent<SpriteRenderer>();
	}

    public void FadeTo(float alpha)
	{
        if(goingForAlpha != alpha)
		{
            if(currentFade != null)
			{
                StopCoroutine(currentFade);
                currentFade = null;
			}
		}

        if(currentFade == null && _renderer.color.a != alpha)
		{
            goingForAlpha = alpha;

            currentFade = fadeTo(alpha);
            StartCoroutine(currentFade);
        }
	}

    private IEnumerator fadeTo(float alpha)
	{
        while(_renderer.color.a != alpha)
		{
            float delta = alpha - _renderer.color.a;

            // Fadeout
            if (delta < 0)
            {
                _renderer.color = new Color
                (
                    _renderer.color.r,
                    _renderer.color.g,
                    _renderer.color.b,
                    _renderer.color.a - (Time.fixedDeltaTime * fadeSpeed)
                );

                if (_renderer.color.a < alpha)
                    _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, alpha);
            }
            // Fadein
            else
            {
                _renderer.color = new Color
                (
                    _renderer.color.r,
                    _renderer.color.g,
                    _renderer.color.b,
                    _renderer.color.a + (Time.fixedDeltaTime * fadeSpeed)
                );

                if (_renderer.color.a > alpha)
                    _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, alpha);
            }
            yield return new WaitForFixedUpdate();
        }
        currentFade = null;
	}
}
