using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalpitarIndicador : MonoBehaviour {

	public float fsize;
	public Transform t;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update() {

		Debug.Log(Mathf.Abs(Mathf.Sin(Time.time)));
		float x = fsize * Mathf.Sin(Time.time);
		t.localScale += new Vector3(x, x, x);
	
	}
}
