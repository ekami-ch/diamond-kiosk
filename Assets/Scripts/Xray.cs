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

    private List<GameObject> targetList = new List<GameObject>();

    public Material xrayMaterial;
    public UnityEvent onXrayEnabled;
    public UnityEvent onXrayDisabled;
    private Toggle currentToggle;
    
    // Start is called before the first frame update
    void Start()
    {
        currentToggle = GetComponent<Toggle>();
        // For each object to xray
        foreach(GameObject targetObject in xrayTargetList) {
            // If the object doesn't have a Renderer
            if(targetObject.GetComponent<Renderer>() == null) {
                // Get all the child elements
                foreach(Transform childGameObject in targetObject.GetComponentsInChildren<Transform>()) {
                    // If child has renderer, add the object to targetList and his material to old material list
                    if(childGameObject.gameObject.GetComponent<Renderer>() != null) {
                        targetList.Add(childGameObject.gameObject);
                        xrayTargetOldMaterial.Add(childGameObject.gameObject.GetComponent<Renderer>().material);
                    }                
                }
            }
            else {
                targetList.Add(targetObject);
                xrayTargetOldMaterial.Add(targetObject.GetComponent<Renderer>().material);
            }
                
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
    {}

    public void activateXray() {
        // Reset old material List
        xrayTargetOldMaterial = new List<Material>();
        // For each object to xray
        foreach(GameObject targetObject in targetList) {
            xrayTargetOldMaterial.Add(targetObject.GetComponent<Renderer>().material);
        }
        foreach(GameObject targetObject in targetList) {
            xrayTargetOldMaterial.Add(targetObject.GetComponent<Renderer>().material);
            targetObject.GetComponent<Renderer>().material = xrayMaterial;
        }
        foreach(GameObject targetObject in hideTargetList) {
            targetObject.SetActive(false);
        }
    }

    public void disableXray() {
        for (int index = 0; index < targetList.Count; index++) {
            targetList.ToArray()[index].GetComponent<Renderer>().material = xrayTargetOldMaterial.ToArray()[index];
        }
        foreach(GameObject targetObject in hideTargetList) {
            targetObject.SetActive(true);
        }
    }
    

}
