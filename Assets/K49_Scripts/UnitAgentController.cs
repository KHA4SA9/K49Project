using UnityEngine;
using UnityEngine.AI;

public class UnitAgentController : MonoBehaviour {
    
    public Ray RayMouse;
    public static RaycastHit HitMouse;
    public NavMeshAgent UnitAgent;
    public bool follow;

    void Awake ()
    {
        UnitAgent = gameObject.GetComponent<NavMeshAgent>();
        BoxSelecter.unit.Add(gameObject);
    }
    
    // Update is called once per frame
    void Update () {

        if (follow)
        {
            UnitAgent.SetDestination(HitMouse.collider.gameObject.transform.position);
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
                UnitAgent.SetDestination(HitMouse.point);
            }
            if (HitMouse.collider.gameObject.layer != LayerMask.NameToLayer("Default"))
            {
                follow = true;
            }
        }
    }
}
