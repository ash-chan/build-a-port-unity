using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateTower : MonoBehaviour {

    // Use this for initialization
    public void changeSceneCrateTower(string Game_Stack)
    {
        Application.LoadLevel(Game_Stack);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
