using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoom : MonoBehaviour {

    public GameObject[] Characters;
	// Use this for initialization
	void Start () {
        Characters = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void BACK()
    {

    }
    public void SELECT()
    {

    }
    public void NEXT()
    {

    }
}
