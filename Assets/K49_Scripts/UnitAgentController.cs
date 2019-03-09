using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnitFollowMasterAgent))]
public class UnitAgentController : MonoBehaviour {
    
    public Ray RayMouse;
    public static RaycastHit HitMouse;
    public NavMeshAgent UnitAgent;
    public static Vector3 vector3_local_position;

    void Awake ()
    {
        UnitAgent = gameObject.GetComponent<NavMeshAgent>();
        BoxSelecter.unit.Add(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetMouseButtonDown(1))
        {
            RayMouse = CameraController.MainCameraGameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(RayMouse, out HitMouse))
            {
                if (HitMouse.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
                {
                    UnitFollowMasterAgent.follow = false;
                    UnitAgent.SetDestination(HitMouse.point);
                }
                if (HitMouse.collider.gameObject.layer != LayerMask.NameToLayer("Default"))
                {
                   UnitFollowMasterAgent.follow = true;
                }
            }
        }

        
    }
}
