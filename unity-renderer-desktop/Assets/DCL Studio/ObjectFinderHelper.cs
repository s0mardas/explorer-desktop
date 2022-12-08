using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ObjectFinderHelper : MonoBehaviour
{
    [SerializeField]
    GameObject mainCamera;

    [SerializeField]
    GameObject playerFakeCamera;

    [SerializeField]
    LayerMask cullMaskCameras;

    [SerializeField]
    GameObject virtualStudioCanvas;

    void Start()
    {

    }

    void Update()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            mainCamera.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
            GameObject personCamera = GameObject.Find("ThirdPerson_VC");

            mainCamera.GetComponent<Camera>().cullingMask = cullMaskCameras;
            virtualStudioCanvas.transform.SetAsLastSibling();


            playerFakeCamera.transform.parent = personCamera.transform;
            playerFakeCamera.transform.localPosition = UnityEngine.Vector3.zero;
            playerFakeCamera.transform.localRotation = Quaternion.Euler(-37.721f, 0, 0);
            playerFakeCamera.SetActive(true);
        }


    }

}
