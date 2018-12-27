using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public Camera MainCamera;
    public GameObject Player;
    public static Ray ray;
    public static RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.gameObject.AddComponent<PlayerAgentController>();
        Player.gameObject.GetComponent<PlayerAgentController>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ray = CameraController.MainCameraGameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        }
    }
}