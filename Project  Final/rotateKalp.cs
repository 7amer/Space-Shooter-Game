using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateKalp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, 1.5f, 0f));
    }
}
