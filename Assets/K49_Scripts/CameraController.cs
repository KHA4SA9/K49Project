using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour {

    public Vector3 SpawnPosition = new Vector3(250, 5, 250),CameraRotation = new Vector3(45, 0, 0);
    public float cMoveSpeed = 50, cZoomSpeed = 50;
    public static GameObject MainCameraPivotGameObject, MainCameraGameObject;
    private CharacterController cMoveController, cZoomController;
    private Vector3 cMove,cZoom;

	// Use this for initialization
	void Start () {
        MainCameraPivotGameObject = new GameObject("MainCameraPivotGameObject");
        MainCameraPivotGameObject.tag = "MainCameraPivot";
        MainCameraGameObject = new GameObject("MainCameraGameObject");
        MainCameraGameObject.transform.parent = MainCameraPivotGameObject.transform;
        MainCameraGameObject.AddComponent<Camera>();
        MainCameraGameObject.AddComponent<AudioListener>();
        MainCameraGameObject.tag = "MainCamera";
        MainCameraGameObject.transform.position = SpawnPosition;
        MainCameraGameObject.transform.eulerAngles = CameraRotation;

        cMoveController = MainCameraPivotGameObject.AddComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {

        cMove = new Vector3(Input.GetAxis("Horizontal"), -1 * Input.GetAxis("Mouse ScrollWheel") * cZoomSpeed, Input.GetAxis("Vertical")) * cMoveSpeed;
        cMoveController.Move(cMove * Time.deltaTime);

	}
}
