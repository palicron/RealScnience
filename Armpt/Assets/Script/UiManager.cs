using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour {


    public GameManager gm;
    public GameObject elementTab;
    public GameObject CompuestoTab;
    public GameObject navigationButtons;
    public Text eName;
    public Text nEnlases;
    public Text Info;
    public Image symbolo;
	public Text target;
	public Text conbinetext;
    public Text cName;
    public Text nCnlases;
    public Text cInfo;
    public Image csymbolo;
    public Text Cconbinetext;
    private int index = 0;
    private Element sElement;
    private Compuesto sCompuesto;
    private ContainerCtr selectetContainer;
	// Use this for initialization
	void Start () {

        sElement = gm.element[index];
        refreshUi();
        activeElementTab();
		conbinetext.text = "0";

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

    public void nextComponent(int a)
    {
        if (a == 1)
        {
            if (index + 1 < gm.compuestosGuardados.Length)
            {
                index += 1;
                sCompuesto = gm.compuestosGuardados[index];
                refreshUi();
            }
            else
            {
                index = 0;
                sCompuesto = gm.compuestosGuardados[index];
                refreshUi();
            }
        }
        else
        {
            if (index - 1 >= 0)
            {
                index -= 1;
                sCompuesto = gm.compuestosGuardados[index];
                refreshUi();
            }
            else
            {
                index = gm.element.Length - 1;
                sCompuesto = gm.compuestosGuardados[index];
                refreshUi();
            }
        }
    }
    void refreshUi()
    {
        if(sElement!=null)
        {
            eName.text = sElement.Ename;
            nEnlases.text = sElement.numEnlases.ToString();
            Info.text = sElement.info;
            symbolo.sprite = sElement.symbol;
        }
        else if(sCompuesto!=null)
        {
            cName.text = sCompuesto.Ename;
            nCnlases.text = sCompuesto.enlases.ToString();
            cInfo.text = sCompuesto.Informacion;
            csymbolo.sprite = sCompuesto.symbol;
        }
      
    }
    public void assignElement()
    {
        if (selectetContainer.ContainElement != null || sElement == null)
            return;

        selectetContainer.setelemento(sElement);

    }
    public void assignComponent()
    {
        if (selectetContainer.ContainElement != null || sCompuesto==null)
            return;

        selectetContainer.setCompuesto(sCompuesto);

    }

    public void clearElement()
    {
		selectetContainer.clearElement();

	}
    public void clearCompuesto()
    {
        selectetContainer.clearCompuesto();

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
        navigationButtons.SetActive(true);
        CompuestoTab.SetActive(false);
        refreshUi();
    }
    public void activeCompuestoTab()
    {
        CompuestoTab.SetActive(true);
        navigationButtons.SetActive(true);
        elementTab.SetActive(false);
        refreshUi();
    }
	public void convineElement()
	{
		gm.crearcompuesto();
	}
	public void setTect(string dd)
	{
		conbinetext.text = dd;
	}
    public void exit()
    {
        this.gameObject.SetActive(false);
    }
}
