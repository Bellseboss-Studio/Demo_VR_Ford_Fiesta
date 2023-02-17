using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FadeAnimation : MonoBehaviour
{
    [SerializeField] private float fadeDuration;
    [SerializeField] private Color colorFade;
    [SerializeField] private Renderer rend;
    [SerializeField] private bool fadeOnStart;

    public float FadeDuration => fadeDuration;
    
    private void Start()
    {
        if(fadeOnStart) FadeIn();
    }

    public void FadeIn()
    {
        Fade(1,0);
    }

    public void FadeOut()
    {
        Fade(0,1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        rend.gameObject.SetActive(true);
        var time = 0f;
        while (time < fadeDuration)
        {
            var newColor = colorFade;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, time / fadeDuration);
            
            rend.material.SetColor("_Color", newColor);
            
            time += Time.deltaTime;
            yield return null;
        }
        
        
        var finalColor = colorFade;
        finalColor.a = alphaOut;
            
        rend.material.SetColor("_Color", finalColor);
        yield return null;
        rend.gameObject.SetActive(false);
    }
}
