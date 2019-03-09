using UnityEngine;
[RequireComponent(typeof(UnitAgentController))]
[RequireComponent(typeof(UnitHealthController))]
[RequireComponent(typeof(UnitFirstSpawnPointAgent))]

public class UnitController : MonoBehaviour {

    public GameObject UnitSelectIndicator;
    public UnitAgentController UnitAgentController;

    // Use this for initialization
    void Start () {
        UnitAgentController = gameObject.GetComponent<UnitAgentController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            UnitAgentController.MouseHit();
        }
	}

    void OnEnable()
    {
        UnitSelectIndicator.GetComponent<MeshRenderer>().enabled = true;
    }

    void OnDisable()
    {
        UnitSelectIndicator.GetComponent<MeshRenderer>().enabled = false;
    }
}
