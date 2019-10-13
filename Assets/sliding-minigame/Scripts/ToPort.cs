using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToPort : MonoBehaviour {


    public void OnPlayClick(string MainPage)
    {
        Debug.Log("Play button has been clicked!");
        Money.inPort = true;
        Application.LoadLevel(MainPage);
    }
}
