using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MainPlayerAgentController))]

public class MainPlayerController : MonoBehaviour {


    public GameObject MainPlayerSelectIndicator;
    public MainPlayerAgentController MainPlayerAgentController;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MainPlayerAgentController.MouseHit();
        }
    }
    void OnEnable()
    {
        MainPlayerSelectIndicator.GetComponent<MeshRenderer>().enabled = true;
    }

    void OnDisable()
    {
        MainPlayerSelectIndicator.GetComponent<MeshRenderer>().enabled = false;
    }
}
