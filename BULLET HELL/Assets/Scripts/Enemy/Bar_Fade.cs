using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        color_outline = outline.GetComponent<Color>();
        color_inline = inline.GetComponent<Color>();
        color_fill = fill.GetComponent<Color>();

        color_outline.a = 0;
        color_inline.a = 0;
        color_fill.a = 0;

        stay = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (stay >= 0)
        {
            stay--;
        }
        else if (dim != 0)
        {
            color_outline.a = dim;
            color_inline.a = dim;
            color_fill.a = dim;
            dim -= dim_amount;
        }
    }

    public void fade()
    {
        dim = 1;
        stay = temp_stay;

        color_outline.a = dim;
        color_inline.a = dim;
        color_fill.a = dim;
    }
}
