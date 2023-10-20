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

    void Start()
    {
        color_outline = outline.GetComponent<Color>();
        color_inline = inline.GetComponent<Color>();
        color_fill = fill.GetComponent<Color>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
