using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{

    
    public Element[] element;
    public Compuesto[] compuestos;
    public Compuesto[] compuestosGuardados;
    public Compuesto[,,] elements = new Compuesto[12, 12, 12];
    public ContainerCtr ContenedorSelect;
    public GameObject ControlUi;
	public EventSystem es;
    private UiManager uim;
	private PointerEventData pEd;
	GraphicRaycaster m_Raycaster;
    [SerializeField]
    private int[] convinaciones = new int[3];
    [SerializeField]
    private int convIndex = 0;
    private int GcIndex = 0;
	// Use this for initialization
	void Start()
    {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.LandscapeRight;
        DontDestroyOnLoad(this);
        uim = ControlUi.GetComponent<UiManager>();
        ControlUi.SetActive(false);
        for (int i = 0; i < compuestos.Length; i++)
        {
            int x = 0;
            int y = 0;
            int z = 0;

            x = compuestos[i].elementosNesesario[0];
            y = compuestos[i].elementosNesesario[1];
            z = compuestos[i].elementosNesesario[2];
            elements[x, y, z] = compuestos[i];
            elements[z, x, y] = compuestos[i];
            elements[y, z, x] = compuestos[i];
            elements[x, z, y] = compuestos[i];
            elements[y, x, z] = compuestos[i];

        }

    }

    // Update is called once per frame
    void Update()
    {
        Action();

    }

    public void asignarelemento(Element elem)
    {
        if (ContenedorSelect == null)
            return;

        ContenedorSelect.setelemento(elem);
    }

    void Action()
    {
		
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
			//pEd = new PointerEventData(es);
			//pEd.position = Input.GetTouch(0).position;
			//List<RaycastResult> res = new List<RaycastResult>();
			//m_Raycaster.Raycast(pEd, res);
			//if (res.Count !=0)
			//	return;
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Physics.Raycast(ray.origin, ray.direction, out hit, 100f);
            if (hit.rigidbody == null && !hit.transform.gameObject.tag.Equals("UI"))
            {
                clearContainer();
                ControlUi.SetActive(false);
            }
            else if (hit.rigidbody.tag.Equals("Cont"))
            {
                ContenedorSelect = hit.rigidbody.gameObject.GetComponent<ContainerCtr>();
                ControlUi.SetActive(true);
               
                uim.assigContainer(ContenedorSelect);
                
            }
			



        }
    }

    void clearContainer()
    {
        ContenedorSelect = null;
        uim.claerContainer();
    }
    public void reportElement(int id)
    {
       
        if (convIndex < 3)
        {
            convinaciones[convIndex] = id;
            convIndex++;

        }
        else
        {
            convIndex = 0;
            convinaciones[convIndex] = id;

        }

    }
    public void clearelement(int id)
    {
        for(int i =0;i<convinaciones.Length;i++)
        {
            if(convinaciones[i]==id)
            {
                convinaciones[i] = 0;
                return;
            }
        }
    }
    public void crearcompuesto()
    {
        int x = convinaciones[0];
        int y = convinaciones[1];
        int z = convinaciones[2];
        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(z);
        Compuesto cop = elements[x, y, z];
        Debug.Log(cop);
        if (cop == null)
        {
            uim.DisplayMenu(null);
        }
        else
        {
            compuestosGuardados[GcIndex] = cop;
            uim.DisplayMenu(cop.Ename);
            GcIndex++;
        }
		int we = compuestosGuardados.Length;
        uim.refreshUi();
		
    }
}
