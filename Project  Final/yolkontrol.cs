using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yolkontrol : MonoBehaviour {

    Rigidbody fizik;
    public float yolHızı;
	void Start () {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = new Vector3(yolHızı, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
