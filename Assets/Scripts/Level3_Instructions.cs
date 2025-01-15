using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level3_Instructions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectivePanel;
    public GameObject instructionPanel;

    private int currentPage = 1;
    void Start()
    {   
        objectivePanel.SetActive(true);
        instructionPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    // Update is called once per frame
    public void OnnextButton()
    {
        objectivePanel.SetActive(false);
        instructionPanel.SetActive(true);
    }
    public void OnplayButton()
    {
        instructionPanel.SetActive(false);
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }


}
