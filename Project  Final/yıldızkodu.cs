using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yıldızkodu : MonoBehaviour {

    Rigidbody fizik;
    public float yıldızHızı;
    
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = new Vector3(yıldızHızı, 0f, 0f);
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(new Vector3(0f, 1.5f, 0f));
    }
  
}
