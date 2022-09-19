using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextureDropdownHandler : MonoBehaviour
{
    // List of material to be used
    public Material[] targetBodiesMaterials;
    // Target object for material change
    public GameObject[] targetBodies;
    private TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
       // Get dropdown component
       dropdown = GetComponent<TMP_Dropdown>();
       // Add listener for dropdown when value change
       dropdown?.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }
    void DropdownItemSelected(TMP_Dropdown targetDropdown) 
    {
        // Get index for the targetBodiesMaterial's value
        int index = targetDropdown.value;
        // For each targeted bodies, get and change its texture
        foreach (var body in targetBodies)
        {
            Debug.Log(body);
            body.GetComponent<Renderer>().material = targetBodiesMaterials[index];
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
