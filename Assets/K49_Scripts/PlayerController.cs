using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(KeyReader))]

public class PlayerController : MonoBehaviour {

    public float speed = 6.0f, jumpSpeed = 8.0f, gravity = 20.0f,xMouse,yMouse;
    private int i;
    private Vector3 moveDirection = Vector3.zero, rotateDirection = Vector3.zero;
    public Vector3 BodyRotateDirection = Vector3.zero,HeadRotateDirection = Vector3.zero;
    private Quaternion Brot = Quaternion.identity,HeadRotation = Quaternion.identity,rotation,Hrot;
    private CharacterController CC;
    public Transform TargetCube;
    GameObject Head;

	// Use this for initialization
	void Start () {
        CC = GetComponent<CharacterController>();
        Head = GameObject.FindGameObjectWithTag("Head");
	}
	
	// Update is called once per frame
	void Update () {
       
     //Move player body
        if (CC.isGrounded)
        {
            moveDirection = new Vector3(KeyReader.x,0,KeyReader.z);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (KeyReader.Jump)
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity* Time.deltaTime;
        CC.Move(moveDirection * Time.deltaTime);

        //Rotate player body

        //If player move, head rotation = KeyReader.xMouse
        if (KeyReader.z != 0 || KeyReader.x != 0 || KeyReader.z != 0 && KeyReader.x != 0)
        {
            transform.Rotate(new Vector3(0f, KeyReader.xMouse, 0f));
        }


        //If player stand, head rotation = 90
        if (KeyReader.z == 0) {
            if (HeadRotateDirection.y == 90) {
                transform.Rotate(new Vector3(0f, KeyReader.xMouse, 0f));
            } else if (HeadRotateDirection.y == -90)
            {
                transform.Rotate(new Vector3(0f, KeyReader.xMouse, 0f));
            }
        }
        //Rotate player head

        //If player move,body rotation = head rotation,head rotation 0
        if (KeyReader.z != 0 || KeyReader.x != 0 || KeyReader.z != 0 && KeyReader.x != 0)
        {
            
            while (i == 0) {
                transform.Rotate(new Vector3(0f,HeadRotateDirection.y,0f));
                HeadRotateDirection = new Vector3(HeadRotateDirection.x, 0f, 0f);
                i++;
            }
        }else {
            i = 0;
            HeadRotateDirection += new Vector3(0f, KeyReader.xMouse, 0f);
        }

        HeadRotateDirection += new Vector3(KeyReader.yMouse * -1, 0f, 0f);

        HeadRotateDirection.x = Mathf.Clamp(HeadRotateDirection.x, -90, 90); //X-axis constraint
        HeadRotateDirection.y = Mathf.Clamp(HeadRotateDirection.y, -90, 90); //Y-axis constraint

        HeadRotation = Quaternion.Euler(HeadRotateDirection.x, HeadRotateDirection.y, 0f);
        Hrot = Head.transform.localRotation = HeadRotation;
    }
}
