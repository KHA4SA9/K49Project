using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MainPlayerHealthController))]

public class MainPlayerAgentController : MonoBehaviour {

    public Ray RayMouse;
    public RaycastHit HitMouse;
    public NavMeshAgent MainPlayerAgent;
    public bool follow;


    void Awake()
    {
        MainPlayerAgent = gameObject.GetComponent<NavMeshAgent>();
        BoxSelecter.unit.Add(gameObject);
    }

    

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            MainPlayerAgent.SetDestination(HitMouse.collider.gameObject.transform.position);
        }
    }

    public void MouseHit()
    {
        RayMouse = CameraController.MainCameraGameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(RayMouse, out HitMouse))
        {
            if (HitMouse.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                follow = false;
                MainPlayerAgent.SetDestination(HitMouse.point);
            }
            if (HitMouse.collider.gameObject.layer != LayerMask.NameToLayer("Default"))
            {
                follow = true;
            }
        }
    }
}
