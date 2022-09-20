using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FpsCounter : MonoBehaviour
{
    private float timer;
    public TMP_Text targetText;
    private float hudRefreshRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(Time.unscaledTime > timer & targetText != null)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            targetText.text = "FPS : " + fps;
            timer = Time.unscaledTime + hudRefreshRate;
        }
    }
}
