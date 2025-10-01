using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System;

public class TypingEffect : MonoBehaviour
{
    float typingSpeed;
    public Coroutine Run(string text, TMP_Text textBox)
    {
        typingSpeed = 20;
        return StartCoroutine(TypeText(text, textBox));
    }
    
     public Coroutine Run(string text, TMP_Text textBox, float speed)
    {
        typingSpeed = speed;
        return StartCoroutine(TypeText(text, textBox));
    }

    private IEnumerator TypeText(string text, TMP_Text textBox)
    {
        textBox.text = String.Empty;

        int currLength = 0;
        float time = 0;
        int textLength = text.Length;

        while (currLength < textLength)
        {
            time += Time.deltaTime * typingSpeed;

            currLength = Mathf.FloorToInt(time);
            currLength = Mathf.Clamp(currLength, 0, textLength);


            string currText = text.Substring(0, currLength);
            if (currText.EndsWith("\\"))
            {
                currText = text.Substring(0, currLength - 1);
            }
            else if (currText.EndsWith(". ") || currText.EndsWith("? "))
            {
                yield return new WaitForSeconds(0.003f);
            }
            textBox.text = currText;

            yield return null;
        }

        textBox.text = text;
    }
}
