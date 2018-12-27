using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public GameObject Cube;
    public GameObject MainBuildingGameObject, UIButtonsGameObject;
    private Transform MainBuildingGameObjectTransform;
    public Vector3 Main_Building_UnitSpawnPoint;

	// Use this for initialization
	void Start () {
        MainBuildingGameObject = GameObject.Find("Main_Building/Main_Building_UnitSpawnPoint");
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
                        Debug.Log("Touched player");
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
        Main_Building_UnitSpawnPoint = MainBuildingGameObject.transform.position;
        Instantiate(Cube, Main_Building_UnitSpawnPoint, Quaternion.identity );
    }
}
