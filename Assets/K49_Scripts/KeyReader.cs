using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyReader : MonoBehaviour {

    public static float x, y, z,xMouse,yMouse;
    public static bool Jump;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        xMouse = Input.GetAxisRaw("Mouse X");
        yMouse = Input.GetAxisRaw("Mouse Y");
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        Jump = Input.GetButton("Jump");
	}
}
