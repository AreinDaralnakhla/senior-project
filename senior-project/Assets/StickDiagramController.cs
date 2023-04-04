using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StickDiagramController : MonoBehaviour
{
    private Button diagramButton;
    private bool diagramVisable = false;
    private GameObject stickDiagramImage;

    // Start is called before the first frame update
    void Start()
    {
        diagramButton = GameObject.Find("Canvas").GetComponentInChildren<Button>();
        diagramButton.GetComponentInChildren<TMP_Text>().text = "Show Diagram";
        diagramButton.onClick.AddListener(onPress);
        stickDiagramImage = GameObject.Find("StickDiagramImage");
        stickDiagramImage.SetActive(diagramVisable);        
    }

    public void onPress()
    {
        Debug.Log(stickDiagramImage.activeSelf);
        if(!diagramVisable) {
            showDiagram(true);
            Debug.Log("Visible -> True ");
        }
        if(diagramVisable) {
            showDiagram(false);
            Debug.Log("Visible -> False ");
        }
        diagramVisable = !diagramVisable;
    }

    public void showDiagram(bool state) {
        if(state) {
            stickDiagramImage.SetActive(true);
        }
        if(!state) {
            stickDiagramImage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
