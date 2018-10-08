using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCtr : MonoBehaviour {

	public Element ContainElement = null;
	public Compuesto ContainCompuesto = null;
	public enlace[] enlaces;
	public GameObject element;
	private bool combine = false;
	// Use this for initialization
	void Start () {
		if(ContainElement == null || ContainCompuesto!=null)
		{
			clearlinks();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setelemento(Element el)
	{
		ContainElement = el;
		element.SetActive(true);
		activelinks(el.numEnlases);

	}

	void activelinks(int numi)
	{
		for(int i = 0;i<numi;i++)
		{
			enlaces[i].gameObject.SetActive(true);
		}
	}
	void clearlinks()
	{
		foreach (enlace el in enlaces)
		{
			el.gameObject.SetActive(false);
		}
	}
}
