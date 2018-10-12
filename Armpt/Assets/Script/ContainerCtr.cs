using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCtr : MonoBehaviour {
	public GameManager gm;
	public Element ContainElement = null;
	public Compuesto ContainCompuesto = null;
	public enlace[] enlaces;
	public GameObject element;
	public int combine = 0;

	private bool reporto = false;
	// Use this for initialization
	void Start () {
        
        if (ContainElement == null || ContainCompuesto!=null)
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
    public void clearElement()
    {
        ContainElement = null;
        element.SetActive(false);
        clearlinks();
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

    public void linked()
    {
        if(!reporto)
        {
            
			if (ContainElement != null)
				reportelement(ContainElement.id);
			else if(ContainCompuesto!=null)
				reportelement(ContainCompuesto.id);
			reporto = true;
			combine++;
		}
		else
			combine++;


	}
    public void delink()
    {
        combine--;
        if (combine == 0)
		{
			remobeelemtn(ContainElement.id);
			reporto = false;
		}
       

    }
    public void reportelement(int lid)
    {
		gm.reportElement(lid);

	}
    public void remobeelemtn(int lid)
    {
		gm.clearelement(lid);
    }
}
