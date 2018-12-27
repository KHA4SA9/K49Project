using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour {

    public GameObject UIButtonsGameObject, Main_Building;
    public Component PAC;

	// Use this for initialization
	void Start () {
        Main_Building = GameObject.Find("Main_Building");
        UIButtonsGameObject = GameObject.FindGameObjectWithTag("PlayerUIButtons");

        UIButtonsGameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = CameraController.MainCameraGameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //если тронули объект с тегом
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Building"))
                    {
                        UIButtonsGameObject.SetActive(true);
                    }
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                    {
                        Debug.Log(hit.collider);
                        PAC = hit.collider.gameObject.GetComponent<PlayerAgentController>();
                        PAC.gameObject.GetComponent<PlayerAgentController>().enabled = true;
                    }
                    if (PAC != null) {
                        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Default")) {
                            PAC.gameObject.GetComponent<PlayerAgentController>().enabled = false;
                        }
                    }
                }
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            UIButtonsGameObject.SetActive(false);
        }
    }
    public void SpawnCube()
    {
        Main_Building.gameObject.GetComponent<MainBuilding>().SpawnCube();
    }
}
