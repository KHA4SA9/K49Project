using UnityEngine;
using UnityEngine.AI;

public class PlayerAgentController : MonoBehaviour {

    public NavMeshAgent PlayerAgent;
    // Use this for initialization
    void Start () {
        gameObject.AddComponent<NavMeshAgent>();
        PlayerAgent = gameObject.GetComponent<NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(PlayerController.ray, out PlayerController.hit))
        {
            PlayerAgent.SetDestination(PlayerController.hit.point);
        }
    }
}
