using UnityEngine;
using UnityEngine.AI;


public class UnitFollowMasterAgent : MonoBehaviour {

    public NavMeshAgent UnitAgent;
    public static bool follow;
    public Ray RayFollow;
    public RaycastHit HitFollow;
    public Vector3 vector3_master_position;
    // Use this for initialization
    void Awake()
    {
        UnitAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {
        if (follow)
        {
            Transform transform_master_position = UnitAgentController.HitMouse.collider.gameObject.transform;
            vector3_master_position = transform_master_position.transform.position;
            Debug.Log("Following....");
            UnitAgent.SetDestination(vector3_master_position);
        }
    }
}
