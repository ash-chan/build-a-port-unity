using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvacuateTheCrate : MonoBehaviour {

    // Use this for initialization
    public void changeSceneEvacuateTheCrate(string SlidingMinigame)
    {
        Application.LoadLevel(SlidingMinigame);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
