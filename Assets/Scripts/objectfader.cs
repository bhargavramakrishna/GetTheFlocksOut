using UnityEngine;

public class objectfader : MonoBehaviour
{
    public float fadespeed, fadeamount;
    float originalopacity;

    Material Mat;
    public bool DoFade = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mat = GetComponent<Renderer>().material;
        originalopacity = Mat.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (DoFade)
        {
            Fadenow(); 
        }
        else
        {
            ResetFade();
        }
    }

    void Fadenow()
    {

        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeamount, fadespeed * Time.deltaTime));

        Mat.color = smoothColor;    
    }

    void ResetFade()
    {
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, originalopacity, fadespeed * Time.deltaTime));
        Mat.color = smoothColor;
    }
}
