using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_Fade : MonoBehaviour
{

    public GameObject theImage;
    private Color color;
    private byte r;
    private byte g;
    private byte b;

    private byte dim;
    private int startDim;
    private const int temp_startDim = 300;

    void Start()
    {
        color = theImage.GetComponent<Image>().color;
        r = (byte)(color.r * 255);
        g = (byte)(color.g * 255);
        b = (byte)(color.b * 255);
        this.dim = 0;
        this.startDim = 0;

        theImage.GetComponent<Image>().color = new Color32(r, g, b, dim);
    }

    // Update is called once per frame
    void Update()
    {
        if (startDim > 0)
        {
            startDim--;
        }
        else if (dim > 0)
        {
            theImage.GetComponent<Image>().color = new Color32(r, g, b, dim);
            dim--;
        }
    }

    public void fade()
    {
        this.dim = 255;
        this.startDim = temp_startDim;

        theImage.GetComponent<Image>().color = new Color32(r, g, b, dim);
    }
}
