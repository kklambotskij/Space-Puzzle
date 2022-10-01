using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickController : MonoBehaviour
{
    RectTransform rectTransform;
    public void ReduceScale()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale -= new Vector3(0.15f, 0.15f, 0);
    }
    public void EnlargeScale()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale += new Vector3(0.15f, 0.15f, 0);
    }
}
