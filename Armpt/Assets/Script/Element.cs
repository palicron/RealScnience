using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Element", menuName = "Element")]
public class Element : ScriptableObject
{
	public int id;
	public string Ename;
	public Sprite symbol;
	public int numEnlases;
	public string info;
	public Material mat;
    public int numeroElectrones;
    public int numeroProtones;

}
