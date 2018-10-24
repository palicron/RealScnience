using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManagement : MonoBehaviour {


	public string[] nombreEsenas;
	public Text t1;
	public GameObject t2;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		
		t2.SetActive(false);
	}
	private void OnLevelWasLoaded(int level)
	{
		
		
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void loadMenu()
	{
		SceneManager.LoadSceneAsync(nombreEsenas[0]);
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
		
		//t2.enabled = false;
		//GameObject.Find("GameManager").GetComponent<GameManager>().sm = this;
	}
	public void loadQuimica()
	{
		
		//t2.enabled = true;
		SceneManager.LoadSceneAsync(nombreEsenas[1]);
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
		

	}
	public void loadastrono()
	{
		
		//t2.enabled = true;
		SceneManager.LoadSceneAsync(nombreEsenas[2]);
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
		//GameObject.Find("GameManager").GetComponent<GameManager>().sm = this;
	}


}
