using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Level3_NameTag : MonoBehaviour
{
    public string characterName; // Set the default name here.
    private TextMeshProUGUI nameText;

    private void Start()
    {
        nameText = GetComponent<TextMeshProUGUI>();
        if (nameText != null)
        {
            nameText.text = characterName;
        }
    }
}
