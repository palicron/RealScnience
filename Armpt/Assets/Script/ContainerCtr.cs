using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ContainerCtr : MonoBehaviour, ITrackableEventHandler
{
	public GameManager gm;
	public Element ContainElement = null;
	public Compuesto ContainCompuesto = null;
	public enlace enlaces;
	public GameObject element;
    public GameObject Compuesto;
	public TrackableBehaviour track;
	public int combine = 0;
    public Material defmatirial;
	private bool reporto = false;
	private Renderer ren;
	public string dd;
	
	public GameObject targetr;
	private bool con = false;
	public GameObject indicador;
	// Use this for initialization
	void Start () {
		track = this.GetComponentInParent<TrackableBehaviour>();

		
        if (ContainElement == null && ContainCompuesto==null)
		{
			clearlinks();
		}
		else if(ContainElement !=null)
		{
			activelinks(ContainElement.numEnlases);
		}
		else
		{
			activelinks(ContainCompuesto.enlases);
		}
	


	}
	
	// Update is called once per frame
	void Update () {
		if(!istrack())
		{
			enlaces.gameObject.SetActive(false);
			if (reporto)
				delink();

		}
	    else
		{
			enlaces.gameObject.SetActive(true);
		}
	
	

	}

	public void setelemento(Element el)
	{
		ContainElement = el;
		element.SetActive(true);
        element.GetComponent<NucleoControl>().starElement(el.numeroElectrones);
		activelinks(el.numEnlases);

	}
    public void setCompuesto(Compuesto el)
    {
		
        ContainCompuesto = el;
        Compuesto.SetActive(true);
        Compuesto.GetComponent<Renderer>().material = el.mat;
        activelinks(el.enlases);

    }
    public void clearElement()
    {
		delink();
        ContainElement = null;
        element.SetActive(false);
        ContainCompuesto = null;
        Compuesto.SetActive(false);
        ContainElement = null;
        clearlinks();
    }
   
    void activelinks(int numi)
	{
		enlaces.setNlinks(numi);
	}
	void clearlinks()
	{
		enlaces.setNlinks(0);
		delink();
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
		targetr = null;
		con = false;
	 if(combine>0)
        combine--;
       if (combine == 0)
		{
			if(ContainElement!=null)
			remobeelemtn(ContainElement.id);
			else if(ContainCompuesto!=null)
				remobeelemtn(ContainCompuesto.id);
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

	private bool istrack()
	{
		var stat = track.CurrentStatus;
		bool ss = stat == TrackableBehaviour.Status.TRACKED;
		dd = ss.ToString();
		return stat == TrackableBehaviour.Status.TRACKED;  
		
	}

	public void conet(GameObject df)
	{
		targetr = df;
		con = true;
	}
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
		throw new System.NotImplementedException();
	}

    public void intaNomble()
    {
       GameObject ob = GameObject.Instantiate(ContainCompuesto.pregas, this.transform.position, this.transform.rotation);
       ContainCompuesto.intaGas = ob;
        ob.transform.SetParent(this.transform);
    }
}
