using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public float JiggleDuration = 0.5f;
    public float JiggleStrength = 10f;
    public int JiggleVibrato = 10;

    private void OnEnable()
    {
        InvokeRepeating("PlayWarningJiggle", 0f, 2f);
        
    }
    public void PlayWarningJiggle()
    {
        this.GetComponent<RectTransform>().DOShakeAnchorPos(JiggleDuration, JiggleStrength, JiggleVibrato, 90, false, true).SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        CancelInvoke("PlayWarningJiggle");
    }
}
