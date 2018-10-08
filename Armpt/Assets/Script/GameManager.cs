using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Element[] element;
    public Compuesto[] compuestos;
    public Compuesto[] compuestosGuardados;
    public Compuesto[,,] elements = new Compuesto[5, 5, 5];
    public ContainerCtr ContenedorSelect;
    public GameObject ControlUi;
    private UiManager uim;
    // Use this for initialization
    void Start()
    {

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
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Physics.Raycast(ray.origin, ray.direction, out hit, 100f);
            if (hit.rigidbody == null)
            {
               // clearContainer();
               // ControlUi.SetActive(false);
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
}
