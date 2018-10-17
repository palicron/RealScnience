using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbilta : MonoBehaviour {


    public GameObject center;
    public float up;
    
    public float forwar;
    public float cont = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(center.transform);
       transform.RotateAround(center.transform.position, Vector3.up, up * Time.deltaTime);
        
       transform.RotateAround(center.transform.position, Vector3.forward, forwar * Time.deltaTime);

    }

    public void des()
    {
        GameObject.Destroy(this.gameObject);
    }
}
