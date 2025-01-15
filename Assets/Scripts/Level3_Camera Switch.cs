using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_CameraSwitch : MonoBehaviour
{
    [Header("Camera to Assign")]
    public GameObject AimCam;
    public GameObject AimCanvas;
    public GameObject ThirdPersonCam;
    public GameObject ThirdPersonCanvas;
    public GameObject questionCanvas;

    [Header("Cammera Animator")]
    public Animator animator;

    private void Start()
    {
        ThirdPersonCam.SetActive(true);
        ThirdPersonCanvas.SetActive(true);

        AimCam.SetActive(false);
        AimCanvas.SetActive(false);

        questionCanvas.SetActive(false);       
    }
    private void Update()
    {
        if ((Input.GetButton("Fire1") && Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetButton("Fire1")))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("IdleAim", true);
            animator.SetBool("RifleWalk", true);
            animator.SetBool("Walk", true);

            ThirdPersonCam.SetActive(false);
            ThirdPersonCanvas.SetActive(false);
            AimCam.SetActive(true);
            AimCanvas.SetActive(true);
        }
        else if (Input.GetButton("Fire1"))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("IdleAim", true);
            animator.SetBool("RifleWalk", false);
            animator.SetBool("Walk", false);

            ThirdPersonCam.SetActive(false);
            ThirdPersonCanvas.SetActive(false);
            AimCam.SetActive(true);
            AimCanvas.SetActive(true);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("IdleAim", false);
            animator.SetBool("RifleWalk", false);

            ThirdPersonCam.SetActive(true);
            ThirdPersonCanvas.SetActive(true);
            AimCam.SetActive(false);
            AimCanvas.SetActive(false);
        }
    }
}