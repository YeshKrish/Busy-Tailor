using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class ScrollingAnimation : MonoBehaviour
{

    public float scrollSpeed = 50f; 
    public RectTransform rectTransform; 
    public float resetDistance = 500f;
    public float transitionDuration = 1f; 

    private float startPositionY; 
    private Coroutine resetCoroutine;

    void Start()
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }

        startPositionY = rectTransform.anchoredPosition.y;
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        float newY = rectTransform.anchoredPosition.y - scrollSpeed * Time.deltaTime;

        // If the UI has moved past the reset distance, start the smooth reset coroutine
        if (Mathf.Abs(newY - startPositionY) >= resetDistance)
        {
            if (resetCoroutine == null)
            {
                resetCoroutine = StartCoroutine(SmoothReset());
            }
        }
        else
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newY);
        }
    }

    IEnumerator SmoothReset()
    {
        float elapsedTime = 0f;
        Vector2 startPos = rectTransform.anchoredPosition;
        Vector2 endPos = new Vector2(rectTransform.anchoredPosition.x, startPositionY);

        while (elapsedTime < transitionDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = endPos;
        resetCoroutine = null;
    }
}

