using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerGUI : MonoBehaviour {

    public GameObject GUIButtonsGameObject;
    public Ray RayMouse;
    public RaycastHit HitMouse;
    public Collider MPAC,UAC;

    // Use this for initialization
    void Start()
    {
        GUIButtonsGameObject = GameObject.FindGameObjectWithTag("PlayerGUIButtons");
        GUIButtonsGameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RayMouse = CameraController.MainCameraGameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            

            if (Physics.Raycast(RayMouse, out HitMouse))
            {
                if (HitMouse.collider != null)
                {
                    //если тронули объект с тегом
                    if (HitMouse.collider.gameObject.layer == LayerMask.NameToLayer("Building"))
                    {
                        GUIButtonsGameObject.SetActive(true);
                    }
                    if (HitMouse.collider.gameObject.layer == LayerMask.NameToLayer("MainPlayer"))
                    {
                        HitMouse.collider.gameObject.GetComponent<MainPlayerAgentController>().enabled = true;
                        MPAC = HitMouse.collider;
                    }
                    if (HitMouse.collider.gameObject.layer == LayerMask.NameToLayer("Unit"))
                    {
                        HitMouse.collider.gameObject.GetComponent<UnitAgentController>().enabled = true;
                        UAC = HitMouse.collider;
                    }
                    if (HitMouse.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
                    {
                        Cancel();
                    }
                }
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Cancel();
           
        }
    }
    void Cancel()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            GUIButtonsGameObject.SetActive(false);
        }
        if (MPAC != null)
        {
            MPAC.gameObject.GetComponent<MainPlayerAgentController>().enabled = false;
        }
        if (UAC != null)
        {
            UAC.gameObject.GetComponent<UnitAgentController>().enabled = false;
        }
    }
}
