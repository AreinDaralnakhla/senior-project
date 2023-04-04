using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class labelButtonController : MonoBehaviour
{
    
    private bool isMaterialsChanged = false; 
    public Material GATE_Label;
    public Material METAL_Label;
    public Material METAL_Label1;
    public Material N_WELL_Label;
    public Material PMOS_Label;
    public Material NMOS_Label;
    public Material SiO2_Label;
    public Material Substrate_Label;

    private TextMeshProUGUI labelButton;
    private TMP_Dropdown dropdown;

    private Dictionary<GameObject, Material[]> originalMaterials = new Dictionary<GameObject, Material[]>();
    

    private void Start()
    {
       GameObject cmosInverter = GameObject.Find("cmos_inverter");
        dropdown = GameObject.Find("Canvas").GetComponentInChildren<TMP_Dropdown>();

        if (cmosInverter != null)
        {
            StoreColors(cmosInverter.transform);
        }
    }

    public void StoreColors(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Renderer renderer = child.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                originalMaterials[child.gameObject] = renderer.materials;
            }
            StoreColors(child);
        }
    }

    

    public void ChangeMaterials()
    {
        GameObject cmosInverter = GameObject.Find("cmos_inverter");
        if (cmosInverter != null)
        {
            if (!isMaterialsChanged) // set label materials
            {
                foreach (Transform child in cmosInverter.transform)
                {
                    if (child.gameObject.name.Equals("input") ||
                        child.gameObject.name.Equals("output"))
                    {
                        child.gameObject.GetComponent<Renderer>().material = METAL_Label; // Set the METAL_Label material for the input, output, VDD, and GND children
                    }

                    else if (child.gameObject.name.Equals("vdd") ||
                            child.gameObject.name.Equals("gnd"))
                    {
                        child.gameObject.GetComponent<Renderer>().material = METAL_Label1; // Set the METAL_Label material for the input, output, VDD, and GND children

                    }
                    
                    else if (child.gameObject.name.Equals("pmos")){
                        foreach (Transform pmosChild in child.transform)
                        {
                            if (pmosChild.gameObject.name.Equals("p1") || pmosChild.gameObject.name.Equals("p2"))
                            {
                                pmosChild.gameObject.GetComponent<Renderer>().material = PMOS_Label; // Set the PMOS_Label material for the p1 and p2 children of pmos
                            }
                            else if (pmosChild.gameObject.name.Equals("pmos_gate"))
                            {
                                pmosChild.gameObject.GetComponent<Renderer>().material = GATE_Label; // Set the PMOS_Label material for the p1 and p2 children of pmos
                            }
                            else if (pmosChild.gameObject.name.Equals("pmos_si"))
                            {
                                pmosChild.gameObject.GetComponent<Renderer>().material = SiO2_Label; // Set the PMOS_Label material for the p1 and p2 children of pmos
                            }
                            else if (pmosChild.gameObject.name.Equals("pmos_substrate"))
                            {
                                pmosChild.gameObject.GetComponent<Renderer>().material = Substrate_Label; // Set the PMOS_Label material for the p1 and p2 children of pmos
                            }
                            else if (pmosChild.gameObject.name.Equals("n_well"))
                            {
                                pmosChild.gameObject.GetComponent<Renderer>().material = N_WELL_Label; // Set the PMOS_Label material for the p1 and p2 children of pmos
                            }
                        }
                    }
                            
                    else if (child.gameObject.name.Equals("nmos")){
                        foreach (Transform pmosChild in child.transform)
                        {
                            if (pmosChild.gameObject.name.Equals("n1") || pmosChild.gameObject.name.Equals("n2"))
                            {
                                pmosChild.gameObject.GetComponent<Renderer>().material = NMOS_Label; // Set the PMOS_Label material for the p1 and p2 children of pmos
                            }
                            else if (pmosChild.gameObject.name.Equals("nmos_gate"))
                            {
                                pmosChild.gameObject.GetComponent<Renderer>().material = GATE_Label; // Set the PMOS_Label material for the p1 and p2 children of pmos
                            }
                            else if (pmosChild.gameObject.name.Equals("nmos_si"))
                            {
                                pmosChild.gameObject.GetComponent<Renderer>().material = SiO2_Label; // Set the PMOS_Label material for the p1 and p2 children of pmos
                            }
                            else if (pmosChild.gameObject.name.Equals("nmos_substrate"))
                            {
                                pmosChild.gameObject.GetComponent<Renderer>().material = Substrate_Label; // Set the PMOS_Label material for the p1 and p2 children of pmos
                            }
                        }
                    }
                }
            }
        } 
        isMaterialsChanged = true;
    }  
    
    public void ResetColors()
    {
        if (originalMaterials.Count == 0)
        {
            Debug.Log("No original colors stored.");
            return;
        }
        
        foreach (var kvp in originalMaterials)
        {
            GameObject child = kvp.Key;
            Material[] originalMats = kvp.Value;
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.materials = originalMats;
            }
        }
        
        isMaterialsChanged = false;
    }
    
    public void ToggleMaterials() 
    {
            labelButton = GameObject.Find("labelButton").GetComponentInChildren<TextMeshProUGUI>();
            dropdown.value = 0;
            if (!isMaterialsChanged) {
                ChangeMaterials();
                labelButton.text = "Unlabel Components";
            } else {
               ResetColors();
               labelButton.text = "Label Components";
            }
    }
}
