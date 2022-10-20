using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Xray : MonoBehaviour
{
    public List<GameObject> xrayTargetList = new List<GameObject>();
    private List<Material> xrayTargetOldMaterial = new List<Material>();
    public List<Toggle> xrayTargetToggleList = new List<Toggle>();
    public List<GameObject> hideTargetList = new List<GameObject>();

    public Material xrayMaterial;
    public UnityEvent onXrayEnabled;
    public UnityEvent onXrayDisabled;
    private Toggle currentToggle;
    
    // Start is called before the first frame update
    void Start()
    {
        currentToggle = GetComponent<Toggle>();
        foreach(GameObject targetObject in xrayTargetList) {
            xrayTargetOldMaterial.Add(targetObject.GetComponent<Renderer>().material);
        }
        currentToggle.onValueChanged.AddListener(delegate {
            if(currentToggle.isOn) {
                activateXray();
                foreach(Toggle toggle in xrayTargetToggleList)
                {
                    toggle.interactable = false;
                }
            }
            else
            {
                disableXray();
                foreach(Toggle toggle in xrayTargetToggleList)
                {
                    toggle.interactable = true;
                }
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        // if(currentToggle.isOn) {
        //     onXrayEnabled.Invoke();
        // }
        // else
        // {
        //     onXrayDisabled.Invoke();
        // }
    }

    public void activateXray() {
        xrayTargetOldMaterial = new List<Material>();
        foreach(GameObject targetObject in xrayTargetList) {
            xrayTargetOldMaterial.Add(targetObject.GetComponent<Renderer>().material);
        }
        foreach(GameObject targetObject in xrayTargetList) {
            xrayTargetOldMaterial.Add(targetObject.GetComponent<Renderer>().material);
            targetObject.GetComponent<Renderer>().material = xrayMaterial;
        }
        foreach(GameObject targetObject in hideTargetList) {
            targetObject.SetActive(false);
        }
    }

    public void disableXray() {
        for (int index = 0; index < xrayTargetList.Count; index++) {
            xrayTargetList.ToArray()[index].GetComponent<Renderer>().material = xrayTargetOldMaterial.ToArray()[index];
        }
        foreach(GameObject targetObject in hideTargetList) {
            targetObject.SetActive(true);
        }
    }
    

}
