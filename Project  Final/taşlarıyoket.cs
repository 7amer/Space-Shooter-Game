using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taşlarıyoket : MonoBehaviour {

	
	
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag!="Player" && coll.tag!="baundary")
        {
            Destroy(coll.gameObject);
            Debug.Log(coll.name);
        }
         
        //if (coll.tag == "yoltagi")
        //{

        //    Destroy(coll.gameObject);
        //}
        //if (coll.tag == "yıldıztagi")
        //{
        //    Destroy(coll.gameObject);
        //}
        //if(coll.tag=="mermitagi")
        //{
        //    Destroy(coll.gameObject);
        //}
    }
}
