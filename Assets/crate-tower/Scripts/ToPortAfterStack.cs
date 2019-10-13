using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToPortAfterStack : MonoBehaviour {



    public void OnPlayClick(string MainPage)
    {
		Money.currentMoney += TheStack.actualScore * 15;
        Debug.Log("Play button has been clicked!");
        Application.LoadLevel(MainPage);
    }
}
