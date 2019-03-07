using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyboxDöndür : MonoBehaviour {

    public float dönmeHızı;
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * dönmeHızı);
        
    }
   
    
       
    
}
