using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_Fade : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject outline;
    public GameObject inline;
    public GameObject fill;

    private Color color_outline;
    private Color color_inline;
    private Color color_fill;

    private float dim;
    private const float dim_amount = 0.1f;

    private int stay;
    private const int temp_stay = 50;

    void Start()
    {
        color_outline = outline.GetComponent<Image>().color;
        color_inline = inline.GetComponent<Image>().color;
        color_fill = fill.GetComponent<Image>().color;

        color_outline.a = 0f;
        color_inline.a = 0f;
        color_fill.a = 0f;

        stay = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (stay >= 0)
        {
            stay--;
        }
        else if (dim >= 0)
        {
            color_outline.a = dim;
            color_inline.a = dim;
            color_fill.a = dim;
            dim -= dim_amount;
            Debug.Log(color_outline.a);
        }
    }

    public void fade()
    {
        dim = 1f;
        stay = temp_stay;

        color_outline.a = dim;
        color_inline.a = dim;
        color_fill.a = dim;
        Debug.Log(color_outline.a);
    }
}
