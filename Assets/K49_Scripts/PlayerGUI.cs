using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerGUI : MonoBehaviour {

    public GameObject PlayerGUIButtonsGameObject;
    public Ray RayMouse;
    public RaycastHit HitMouse;
    public Collider MPAC,UAC;

    // Use this for initialization
    void Start()
    {
        PlayerGUIButtonsGameObject = GameObject.FindGameObjectWithTag("PlayerGUIButtons");
        PlayerGUIButtonsGameObject.SetActive(false);



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
                        PlayerGUIButtonsGameObject.SetActive(true);
                    }
                    if (HitMouse.collider.gameObject.layer == LayerMask.NameToLayer("MainPlayer"))
                    {
                        Cancel();
                        HitMouse.collider.gameObject.GetComponent<MainPlayerController>().enabled = true;
                        MPAC = HitMouse.collider;
                    }
                    if (HitMouse.collider.gameObject.layer == LayerMask.NameToLayer("Unit"))
                    {
                        Cancel();
                        HitMouse.collider.gameObject.GetComponent<UnitController>().enabled = true;
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
            PlayerGUIButtonsGameObject.SetActive(false);
        }
        if (MPAC != null)
        {
            MPAC.gameObject.GetComponent<MainPlayerController>().enabled = false;
        }
        if (UAC != null)
        {
            UAC.gameObject.GetComponent<UnitController>().enabled = false;
        }
    }
}
