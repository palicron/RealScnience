using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class enlace : MonoBehaviour {

	public int id = 0;
	public int linid = 0;
	public bool linket = false;


	public void setid(int id)
	{
		this.id = id;
	}
	public void setlinkid(int id)
	{
		this.linid = id;
	}

	void clearlinks()
	{
		linid = 0;
	}

	void clearall()
	{
		id = 0;
		linid = 0;
	}
}
