using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    [SerializeField]
    GameObject freeCamera;

    GameObject inputController;

    bool isInFreeCamera = false;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (isInFreeCamera)
            {
                freeCamera.SetActive(false);
                isInFreeCamera = false;
                inputController.SetActive(true);
            }
            else
            {
                freeCamera.SetActive(true);
                isInFreeCamera = true;
                if (inputController == null)
                {
                    inputController = GameObject.Find("InputController");
                }
                inputController.SetActive(false);

                var pos = GameObject.FindGameObjectWithTag("Player").transform.position;
                freeCamera.transform.position = new UnityEngine.Vector3(pos.x, pos.y + 2, pos.z);
            }
        }    
    }


    public void StartFreeCam()
    {
        freeCamera.SetActive(true);
    }





}
