using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ObjectFade : MonoBehaviour
{
    // Start is called before the first frame update

    public float fadeSpeed, fadeAmount;
    float originalOpacity;
    Material Mat;
    public bool DoFade = false;

    void Start()
    {
        Mat = GetComponent<Renderer>().material;
        originalOpacity = Mat.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (DoFade)
            FadeNOW();
        else
            ResetFade();
    }

    void FadeNOW()
    {
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
            Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
        Mat.color = smoothColor;
    }

    void ResetFade()
    {
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
          Mathf.Lerp(currentColor.a, originalOpacity, fadeSpeed * Time.deltaTime));
        Mat.color = smoothColor;
    }
}
