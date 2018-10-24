using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class enlace : MonoBehaviour {

	
	
	public bool linket = false;
	[SerializeField]
	private int nLinks=0;
	private int linkcount;
    private bool report = false;
	private ContainerCtr contenerdor;


	private void Start()
	{
		contenerdor = this.GetComponentInParent<ContainerCtr>();
	}

	public void setNlinks(int n)
	{
		nLinks = n;
		linkcount = nLinks;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Link") && linkcount > 0)
		{
			contenerdor.conet(this.gameObject);
			contenerdor.linked();
			linkcount--;
		}
			
	}

   
    private void OnTriggerExit(Collider other)
	{
        if (other.gameObject.tag.Equals("Link"))
		{
			contenerdor.delink();
			if(linkcount+1<=nLinks)
			{
				linkcount++;
			}
		}
            
	}
}
