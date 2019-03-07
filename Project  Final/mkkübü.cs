using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mkkübü : MonoBehaviour {

    Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            rb.AddForce(0, 300, 0);
        }
	}
}
