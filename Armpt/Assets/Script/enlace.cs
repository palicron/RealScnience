using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class enlace : MonoBehaviour {

	
	
	public bool linket = false;
    private bool report = false;
	private ContainerCtr contenerdor;

	private void Start()
	{
		contenerdor = this.GetComponentInParent<ContainerCtr>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Link"))
			contenerdor.linked();
	}

   
    private void OnTriggerExit(Collider other)
	{
        if (other.gameObject.tag.Equals("Link"))
            contenerdor.delink();
	}
}
