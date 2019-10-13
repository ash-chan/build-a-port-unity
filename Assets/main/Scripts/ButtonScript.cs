using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	public void GoToShopClick (string ShopPage) {
		Debug.Log ("Shop button has been clicked!");
		Money.inPort = false; 
		Application.LoadLevel (ShopPage);
	}

	public void BackToPortClick (string PortPage) {
		Debug.Log ("Back button has been clicked!");
		Money.inPort = true;
		Application.LoadLevel (PortPage);
	}
}
