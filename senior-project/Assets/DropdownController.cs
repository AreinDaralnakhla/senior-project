using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownController : MonoBehaviour
{   
    public Material greyMaterial;
    private TMP_Dropdown dropdown;

    private List<Material> pmosColorsList = new List<Material>();
    private List<Material> nmosColorsList = new List<Material>();
    private List<Material> outputColorsList = new List<Material>();
    private List<Material> inputColorsList = new List<Material>();
    private List<Material> vddColorsList = new List<Material>();
    private List<Material> gndsColorsList = new List<Material>();
    
    private Material[] pmosColors;
    private Material[] nmosColors;
    private Material[] outputColors;
    private Material[] inputColors;
    private Material[] vddColors;
    private Material[] gndsColors;

    private GameObject[] pmosObjs;
    private GameObject[] nmosObjs;
    private GameObject[] outputObjs;
    private GameObject[] inputObjs;
    private GameObject[] VDDObjs;
    private GameObject[] GNDObjs;
    
    [SerializeField] private Image diagramImage;
    [SerializeField] private Sprite allSprite;
    [SerializeField] private Sprite pmosSprite;
    [SerializeField] private Sprite nmosSprite;
    [SerializeField] private Sprite outputSprite;
    [SerializeField] private Sprite inputSprite;
    [SerializeField] private Sprite vddSprite;
    [SerializeField] private Sprite gndSprite;

    private int i = 0;

    // Start is called before the first frame update
    void Start() {
        dropdown = GameObject.Find("Canvas").GetComponentInChildren<TMP_Dropdown>();

        pmosObjs = GameObject.FindGameObjectsWithTag("pmos");
        nmosObjs = GameObject.FindGameObjectsWithTag("nmos");
        outputObjs = GameObject.FindGameObjectsWithTag("output");
        inputObjs = GameObject.FindGameObjectsWithTag("input");
        VDDObjs = GameObject.FindGameObjectsWithTag("vdd");
        GNDObjs = GameObject.FindGameObjectsWithTag("gnd");
        
        storeColors();
    }

    public void OnDropdownValueChanged(int option)
    {
        switch (option)
        {
            case 0: //NONE
                highlight("none");
                break;
            case 1: // PMOS
                highlight("pmos");
                break;
            case 2: // NMOS
                highlight("nmos");
                break;
            case 3: // Output
                highlight("output");
                break;
            case 4: // Input
                highlight("input");
                break;
            case 5: // VDD
                highlight("vdd");
                break;
            case 6: // GND
                highlight("gnd");
                break;
            default:
                break;
        }

    }

    public void storeColors() {
        foreach (GameObject pmosChild in pmosObjs) {
            Renderer renderer = pmosChild.GetComponent<Renderer>();
            if(renderer != null) {
                pmosColorsList.Add(renderer.material);
            }
        }
        pmosColors = pmosColorsList.ToArray();
        i = 0;
        foreach (GameObject nmosChild in nmosObjs) {
            Renderer renderer = nmosChild.GetComponent<Renderer>();
            if(renderer != null) {
                nmosColorsList.Add(renderer.material);
            }
        }
        nmosColors = nmosColorsList.ToArray();
        i = 0;
        foreach (GameObject outputChild in outputObjs) {
            Renderer renderer = outputChild.GetComponent<Renderer>();
            if(renderer != null) {
                outputColorsList.Add(renderer.material);
            }
        }
        outputColors = outputColorsList.ToArray();
        i = 0;
        foreach (GameObject inputChild in inputObjs) {
            Renderer renderer = inputChild.GetComponent<Renderer>();
            if(renderer != null) {
                inputColorsList.Add(renderer.material);
            }
        }
        inputColors = inputColorsList.ToArray();
        i = 0;
        foreach (GameObject vddChild in VDDObjs) {
            Renderer renderer = vddChild.GetComponent<Renderer>();
            if(renderer != null) {
                vddColorsList.Add(renderer.material);
            }
        }
        vddColors = vddColorsList.ToArray();
        i = 0;
        foreach (GameObject gndChild in GNDObjs) {
            Renderer renderer = gndChild.GetComponent<Renderer>();
            if(renderer != null) {
                gndsColorsList.Add(renderer.material);
            }
        }
        gndsColors = gndsColorsList.ToArray();
        i = 0;
    }

    public void unGreyColors() {
        foreach (GameObject pmosChild in pmosObjs) {
            Renderer renderer = pmosChild.GetComponent<Renderer>();
            if(renderer != null) {
                renderer.material = pmosColors[i++];
            }
        }
        i = 0;
        foreach (GameObject nmosChild in nmosObjs) {
            Renderer renderer = nmosChild.GetComponent<Renderer>();
            if(renderer != null) {
                renderer.material = nmosColors[i++];
            }
        }
        i = 0;
        foreach (GameObject outputChild in outputObjs) {
            Renderer renderer = outputChild.GetComponent<Renderer>();
            if(renderer != null) {
                renderer.material = outputColors[i++];
            }
        }
        i = 0;
        foreach (GameObject inputChild in inputObjs) {
            Renderer renderer = inputChild.GetComponent<Renderer>();
            if(renderer != null) {
                renderer.material = inputColors[i++];
            }
        }
        i = 0;
        foreach (GameObject vddChild in VDDObjs) {
            Renderer renderer = vddChild.GetComponent<Renderer>();
            if(renderer != null) {
                renderer.material = vddColors[i++];
            }
        }
        i = 0;
        foreach (GameObject gndChild in GNDObjs) {
            Renderer renderer = gndChild.GetComponent<Renderer>();
            if(renderer != null) {
                renderer.material = gndsColors[i++];
            }
        }
        i = 0;
    }

    public void highlight(string tag){
        unGreyColors();
        if(tag != "pmos") {
            foreach (GameObject pmosChild in pmosObjs) {
                Renderer renderer = pmosChild.GetComponent<Renderer>();
                if(renderer != null) {
                    pmosColors[i++] = renderer.material;
                    renderer.material = greyMaterial;
                }
            }
            i = 0;
        }
        if(tag != "nmos") {
            foreach (GameObject nmosChild in nmosObjs) {
                Renderer renderer = nmosChild.GetComponent<Renderer>();
                if(renderer != null) {
                    nmosColors[i++] = renderer.material;
                    renderer.material = greyMaterial;
                }
            }
            i = 0;
        }
        if(tag != "output") {
            foreach (GameObject outputChild in outputObjs) {
                Renderer renderer = outputChild.GetComponent<Renderer>();
                if(renderer != null) {
                    outputColors[i++] = renderer.material;
                    renderer.material = greyMaterial;
                }
            }
            i = 0;
        }
        if(tag != "input") {
            foreach (GameObject inputChild in inputObjs) {
                Renderer renderer = inputChild.GetComponent<Renderer>();
                if(renderer != null) {
                    inputColors[i++] = renderer.material;
                    renderer.material = greyMaterial;
                }
            }
            i = 0;
        }
        if(tag != "vdd") {
            foreach (GameObject vddChild in VDDObjs) {
                Renderer renderer = vddChild.GetComponent<Renderer>();
                if(renderer != null) {
                    vddColors[i++] = renderer.material;
                    renderer.material = greyMaterial;
                }
            }
            i = 0;
        }
        if(tag != "gnd") {
            foreach (GameObject gndChild in GNDObjs) {
                Renderer renderer = gndChild.GetComponent<Renderer>();
                if(renderer != null) {
                    gndsColors[i++] = renderer.material;
                    renderer.material = greyMaterial;
                }
            }
            i = 0;
        }
        if(tag == "none") {
            unGreyColors();
            diagramImage.sprite = allSprite;
        }
        if(tag == "pmos") {
            diagramImage.sprite = pmosSprite;
        }
        if(tag == "nmos") {
            diagramImage.sprite = nmosSprite;
        }
        if(tag == "output") {
            diagramImage.sprite = outputSprite;
        }
        if(tag == "input") {
            diagramImage.sprite = inputSprite;
        }
        if(tag == "vdd") {
            diagramImage.sprite = vddSprite;
        }
        if(tag == "gnd") {
            diagramImage.sprite = gndSprite;
        }
    }


}
