using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCtr : MonoBehaviour {

	public Element ContainElement = null;
	public Compuesto ContainCompuesto = null;
	public enlace[] enlaces;
	public GameObject element;
	private int combine = 0;
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
            enlaces[i].id = ContainElement.id;

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
        if(combine==0)
        {
            reportelement();
            combine++;
        }
        else
            combine++; 
    }
    public void delink()
    {
        combine--;
        if (combine == 0)
            remobeelemtn();

    }
    public void reportelement()
    {

    }
    public void remobeelemtn()
    {
      
    }
}
