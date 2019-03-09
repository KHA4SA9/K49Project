using UnityEngine;

public class MainBuilding : MonoBehaviour {
    public GameObject Unit;
    public GameObject MainBuildingFirstSpawnPointSpawnGameObject, SpawnedUnitsGameObject;
    public static Vector3 MainBuildingFirstSpawnPoint;

    void Awake() {

        MainBuildingFirstSpawnPointSpawnGameObject = GameObject.Find("Main_Building/MainBuildingFirstSpawnPoint");
        SpawnedUnitsGameObject = new GameObject("SpawnedUnits");
        MainBuildingFirstSpawnPoint = MainBuildingFirstSpawnPointSpawnGameObject.transform.position;
    }

    public void SpawnCube()
    { 
        Instantiate(Unit, transform.position, Quaternion.identity,SpawnedUnitsGameObject.transform);
    }
}
