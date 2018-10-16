using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New compuesto", menuName = "Compuesto")]
public class Compuesto : ScriptableObject {

	public int id;
	public string Ename;
	public Sprite symbol;
	public int[] elementosNesesario;
	public Material mat;
    public int enlases;
    public string Informacion;

}
