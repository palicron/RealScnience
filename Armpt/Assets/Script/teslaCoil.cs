using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teslaCoil : MonoBehaviour {


    public string Neon;

    private void OnTriggerEnter(Collider other)
    {
        FlickeringLight fg = other.gameObject.GetComponent<FlickeringLight>();
        if (fg = null)
            return;

        fg.onmat();
    }

    private void OnTriggerStay(Collider other)
    {
        FlickeringLight fg = other.gameObject.GetComponent<FlickeringLight>();
        if (fg == null)
            return;

        fg.onmat();
    }

    private void OnTriggerExit(Collider other)
    {
        FlickeringLight fg = other.gameObject.GetComponent<FlickeringLight>();
        if (fg == null)
            return;

        fg.offmat();
    }

}
