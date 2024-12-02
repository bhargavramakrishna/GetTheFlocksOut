using UnityEngine;
using UnityEngine.UI;

public class Backgroundimage : MonoBehaviour
{

    [SerializeField] Image targetrenderer;
    private Color backgroundcolor;
    public float oscillationspeed = 1.0f;
    private float mincolorvalue = 0.555f;
    private float maxcolorvalue = 1.0f;
    private float colorvalue;

    private float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        backgroundcolor = targetrenderer.color;
        backgroundcolor.r = colorvalue;
        backgroundcolor.g = colorvalue;
        backgroundcolor.b = colorvalue;
        targetrenderer.color = backgroundcolor;
        time += Time.deltaTime * oscillationspeed;
        colorvalue = Mathf.Lerp(mincolorvalue, maxcolorvalue, (Mathf.Sin(time) + 1.0f) / 2.0f);
    }
}
