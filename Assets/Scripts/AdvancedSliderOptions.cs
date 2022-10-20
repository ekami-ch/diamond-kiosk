using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdvancedSliderOptions : MonoBehaviour
{
    private Slider targetSlider;
    public float scale = 1f;
    // Start is called before the first frame update
    void Start()
    {
        targetSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void valueUp() {
        targetSlider.value += scale;
    }
    public void valueDown() {
        targetSlider.value -= scale;
    }
}
