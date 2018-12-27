using UnityEngine;

public class MainBuilding : MonoBehaviour {
    public GameObject Cube;
    public GameObject MainBuildingGameObject, UIButtonsGameObject;
    public Vector3 Main_Building_UnitSpawnPoint;
    // Use this for initialization
    void Start() {
        MainBuildingGameObject = GameObject.Find("Main_Building/Main_Building_UnitSpawnPoint");
    }

    // Update is called once per frame
    void Update() {

    }
    public void SpawnCube()
    {
        Main_Building_UnitSpawnPoint = MainBuildingGameObject.transform.position;
        Instantiate(Cube, Main_Building_UnitSpawnPoint, Quaternion.identity);
    }
}
