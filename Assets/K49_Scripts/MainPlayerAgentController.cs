using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainPlayerAgentController : MonoBehaviour {

    public Ray RayMouse;
    public RaycastHit HitMouse;
    public NavMeshAgent MainPlayerAgent;


    void Awake()
    {
        MainPlayerAgent = gameObject.GetComponent<NavMeshAgent>();
        BoxSelecter.unit.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(1))
        {
            RayMouse = CameraController.MainCameraGameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(RayMouse, out HitMouse))
            {
                if (HitMouse.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
                {
                    MainPlayerAgent.SetDestination(HitMouse.point);
                }
            }
        }
    }
}
