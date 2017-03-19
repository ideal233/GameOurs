using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 diff;

	// Use this for initialization
	void Start () {
        diff = transform.localPosition - player.transform.localPosition; 

    }
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3((player.transform.localPosition + diff).x,transform.localPosition.y,transform.localPosition.z);
        
	}
}
