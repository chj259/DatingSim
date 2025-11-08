using System;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
public class ChangeBackground : MonoBehaviour
{

    private UnityEngine.UI.Image background_img;
    private float transition;
    private int fade_rate = 100;

    void Start()
    {
        background_img = this.GetComponent<UnityEngine.UI.Image>();
    }

    public void ChangeBackgroundPicture(Sprite background)
    {
        if (background != null)
        {
            background_img.sprite = background;
        }
    }
    public IEnumerator FadeOut()
    {
        transition = 0;
        yield return StartCoroutine(DoFadeOut());

    }
    
    public IEnumerator FadeIn()
    {
        transition = 0;
        yield return StartCoroutine(DoFadeIn());
    }
    IEnumerator DoFadeOut()
    {
        while (transition < 0.025)
        {
            //Debug.Log(transition);
            transition += Time.deltaTime / fade_rate;
            background_img.color = Color.Lerp(background_img.color, Color.black, transition);
            yield return null;
        }

        yield return null;
    }
    
    IEnumerator DoFadeIn()
    {
        while (transition < 0.015)
        {
            transition += Time.deltaTime/fade_rate;
            background_img.color = Color.Lerp(background_img.color, Color.white, transition);
            yield return null;
        }

        yield return null;
    }
}