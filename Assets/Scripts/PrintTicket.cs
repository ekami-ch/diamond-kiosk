using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintTicket : MonoBehaviour
{
    private Animator animTarget;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        animTarget = target.GetComponent<Animator>();
    }

    public void SetBoolPrintTicket()
    {
        if(!animTarget.GetBool("print"))
        {
            target.SetActive(true);
            animTarget.SetBool("print", true);
        }
        else {
            target.SetActive(false);
            animTarget.SetBool("print", false);
        }

        print(animTarget.GetBool("print"));
        
    }
}
