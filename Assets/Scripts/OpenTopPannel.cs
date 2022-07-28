using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenTopPannel : MonoBehaviour
{
    private Animator animTarget;
    public GameObject target;
    void Start()
    {
        animTarget = target.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !animTarget.GetBool("Opened"))
        {
            animTarget.SetBool("Opened", true);
        }
        else if (Input.GetMouseButtonDown(1) && animTarget.GetBool("Opened"))
        {
            animTarget.SetBool("Opened", false);
        }

    }
}
