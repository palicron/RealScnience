using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour {


    public GameManager gm;
    public GameObject elementTab;
    public GameObject CompuestoTab;
    public Text eName;
    public Text nEnlases;
    public Text Info;
    public Image symbolo;
	public Text target;
    private int index = 0;
    private Element sElement;
    private Compuesto sCompuesto;
    private ContainerCtr selectetContainer;
	// Use this for initialization
	void Start () {

        sElement = gm.element[index];
        refreshUi();
        activeElementTab();

    }
	

	// Update is called once per frame
	void Update () {

		target.text = selectetContainer.ToString();
	}


      void  nextElement(int a)
    {
        if (a == 1)
        {
            if (index+1 < gm.element.Length)
            {
                index += 1;
                sElement = gm.element[index];
                refreshUi();
            }
            else
            {
                index = 0;
                sElement = gm.element[index];
                refreshUi();
            }
        }
        else
        {
            if (index - 1 >= 0)
            {
                index -= 1;
                sElement = gm.element[index];
                refreshUi();
            }
            else
            {
                index = gm.element.Length-1;
                sElement = gm.element[index];
                refreshUi();
            }
        }
    }
    void refreshUi()
    {
        eName.text = sElement.Ename;
        nEnlases.text =  sElement.numEnlases.ToString();
        Info.text = sElement.info;
        symbolo.sprite = sElement.symbol;
    }
    public void assignElement()
    {
        if (selectetContainer.ContainElement != null)
            return;

        selectetContainer.setelemento(sElement);

    }
    public void clearElement()
    {
		selectetContainer.clearElement();

	}
    public void assigContainer(ContainerCtr con)
    {
        selectetContainer = con;
	

	}
    public void claerContainer()
    {
        selectetContainer = null;
    }

	public void closeMenu()
	{
		this.gameObject.SetActive(false);
	}

    public void activeElementTab()
    {
        elementTab.SetActive(true);
        CompuestoTab.SetActive(false);
    }
    public void activeCompuestoTab()
    {
        CompuestoTab.SetActive(true);
        elementTab.SetActive(false);
        
    }
}
