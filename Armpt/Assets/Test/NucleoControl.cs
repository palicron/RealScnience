using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleoControl : MonoBehaviour {


    public GameObject electron;
    private int numelec;
    private float count = 0;
    public Renderer ren;
    public GameObject[] electrones;
    public Material disolv;
    public Material stac;
    // Use this for initialization
    void Start() {
        ren = GetComponent<Renderer>();
        ren.material = disolv;
    }

    // Update is called once per frame
    void Update() {

        //if (!ren.isVisible)
        //{
        //    ren.material = disolv;
        //    ren.material.SetFloat("active", 0);
        //    StopAllCoroutines();
        //    return;
        //}
       

        //StartCoroutine("fade");
    }

    public void spwanelectron()
    {
        if (numelec >= electrones.Length && !ren.isVisible)
            return;
        Vector3 vec = new Vector3((this.transform.position.x + 0.4f), (this.transform.position.y), this.transform.position.z);


        GameObject gg = GameObject.Instantiate(electron, vec, Quaternion.identity);
        gg.transform.parent = this.transform;

        gg.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        gg.GetComponent<Orbilta>().up = Random.Range(-100, 100);
        gg.GetComponent<Orbilta>().forwar = Random.Range(-100, 100);
        gg.GetComponent<Orbilta>().center = this.gameObject;
        
        electrones[numelec] = gg;
        numelec++;
    }

   public void eliminateelec()
    {
       
        if (numelec == 0)
            return;
        else
        {

            electrones[numelec-1].GetComponent<Orbilta>().des();
            numelec--;
        }
    }
    
   public void starElement(int num)
    {
        while(numelec>0)
        {
            eliminateelec();
        }
        for(int i =0;i<num;i++)
        {
            spwanelectron();
        }
    }
   IEnumerator  fade()
    {
     
        yield return new WaitForSecondsRealtime(3f);
        ren.material = stac;
    }
}
