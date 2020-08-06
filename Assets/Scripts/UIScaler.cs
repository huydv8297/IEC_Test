using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaler : MonoBehaviour
{
    [SerializeField] private Transform buttonContainerTransform;
    [SerializeField] private float normalScaleValue = 1080f / 1920f;
    [SerializeField] private float scaleValue;

    void Awake()
    {
        scaleValue = (float) Screen.width / Screen.height;
        scaleValue = (float) scaleValue / normalScaleValue;
        if(scaleValue > 1)
            scaleValue = 1;
        buttonContainerTransform.localScale = new Vector3(scaleValue, scaleValue, 1f);
    }

}
