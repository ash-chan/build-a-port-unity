using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toGame : MonoBehaviour {

    GameObject ins, manager;

    public void OnMouseDown()
    {
        ins = GameObject.Find("InstructionsCanvas");
        ins.SetActive(false);
        manager = GameObject.Find("Manager");
        manager.GetComponent<Timer>().start = true;
    }

}
