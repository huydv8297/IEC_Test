using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharactor : MonoBehaviour
{

    [SerializeField] GameObject charactorPos;
    private void OnEnable() {
        charactorPos.SetActive(true);
    }

    private void OnDisable() {
        charactorPos.SetActive(false);
    }
}
