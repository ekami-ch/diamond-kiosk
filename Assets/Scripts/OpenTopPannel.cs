using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenTopPannel : MonoBehaviour
{
    private Animator animTarget;
    private Animator ticketAnimatorTarget;
    private MeshRenderer ticketRenderer;
    public GameObject target;
    public GameObject ticket;

    public GameObject printButton;
    void Start()
    {
        animTarget = target.GetComponent<Animator>();
        if(ticket != null)
        {
            ticketAnimatorTarget = ticket.GetComponent<Animator>();
            ticketRenderer = ticket.GetComponent<MeshRenderer>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(1) && !animTarget.GetBool("Opened"))
        // {
        //     animTarget.SetBool("Opened", true);
        //     if(ticket != null) {
        //         ticketAnimatorTarget.SetBool("print", false);
        //         ticketRenderer.enabled = false;
        //         printButton.SetActive(false);
        //     }
            
        // }
        // else if (Input.GetMouseButtonDown(1) && animTarget.GetBool("Opened"))
        // {
        //     animTarget.SetBool("Opened", false);
        //     if(ticket != null) {
        //         ticketAnimatorTarget.SetBool("print", false);
        //         ticketRenderer.enabled = true;
        //         printButton.SetActive(true);
        //     }
            
        //}

    }

    public void OpenOrCloseTopPannel() {
        if (!animTarget.GetBool("Opened"))
        {
            animTarget.SetBool("Opened", true);
            if(ticket != null) {
                ticketAnimatorTarget.SetBool("print", false);
                //ticketRenderer.enabled = false;
                //printButton.SetActive(false);
            }
            
        }
        else if (animTarget.GetBool("Opened"))
        {
            animTarget.SetBool("Opened", false);
            if(ticket != null) {
                ticketAnimatorTarget.SetBool("print", false);
                //ticketRenderer.enabled = true;
                //printButton.SetActive(true);
            }
            
        }
    }
}
