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
	// Use this for initialization
	void Start()
	{
	
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
		
	}

	public void asignarelemento(Element elem)
	{
		if (ContenedorSelect == null)
			return;

		ContenedorSelect.setelemento(elem);
	}
}
