using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery_Dash_Notification : MonoBehaviour {

    // Use this for initialization
    public void changeSceneDeliveryDash(string DeliveryDash)
    {
        Application.LoadLevel(DeliveryDash);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
