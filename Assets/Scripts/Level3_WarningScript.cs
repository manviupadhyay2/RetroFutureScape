using UnityEngine;
using UnityEngine.UI;
public class Level3_WarningScript : MonoBehaviour
{
    public GameObject warningCanvas; // Reference to the warning canvas GameObject

    private bool playerEntered = false;

    private void Update()
    {
        if (playerEntered)
        {
            warningCanvas.SetActive(true);

            Destroy(warningCanvas, 6f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Adjust the tag as needed
        {
            playerEntered = true;
        }
    }

}