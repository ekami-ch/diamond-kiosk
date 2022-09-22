using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeColor : MonoBehaviour
{
    public FlexibleColorPicker fcp;
    public Material[] materials;
    public Image[] images;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var material in materials)
        {
            material.color = fcp.color;
        }
        foreach (var image in images)
        {
            image.color = fcp.color;
        }
    }
}
