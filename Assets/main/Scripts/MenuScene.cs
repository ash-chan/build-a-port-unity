using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour {

	private CanvasGroup fadeGroup;
	private float fadeInSpeed = 0.33f;

	public RectTransform menuContainer;
	public Transform portAsset;
	//public Transform extraAsset;

	public Text portAssetBuySet;
	//public Text extraAssetBuySet;
	public Text goldText;



	private int []portAssetCost = new int[] {2000,10000,5000};
	//private int []extraAssetCost = new int[] {0,5,5,5,5,5,5,5,5,5};
	private int selectedPortAssetIndex;
	//private int selectedExtraAssetIndex;
	private int activePortAssetIndex;
	//private int activeExtraAssetIndex;




	private Vector3 desiredMenuPosition;

	void Start() {
		


		//Temporary gold for testing
		//SaveManager.Instance.state.gold = 500000;
		SaveManager.Instance.updateCash (Money.currentMoney);

		//Tell our gold text how much it should display
		UpdateGoldText();

		//Grab the only CanvasGroup in the scene
		fadeGroup = FindObjectOfType<CanvasGroup> ();

		//Start with white screen
		fadeGroup.alpha = 1;

		//add button on-click events to shop buttons
		InitShop ();

		//Set Player's Pref
		OnPortAssetSelect(SaveManager.Instance.state.activePortAsset);
		SetPortAsset(SaveManager.Instance.state.activePortAsset);

//		OnExtraAssetSelect(SaveManager.Instance.state.activeExtraAsset);
//		SetExtraAsset(SaveManager.Instance.state.activeExtraAsset);

		//Make buttons bigger for the selected items
		portAsset.GetChild(SaveManager.Instance.state.activePortAsset).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;
		//extraAsset.GetChild(SaveManager.Instance.state.activeExtraAsset).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;


	}

	private void Update () {
		//Fade in
		fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;

		//Menu navigation (smooth)
		menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D, desiredMenuPosition, 0.1f);
	}

	private void InitShop(){
		
		//just make sure we've assigned the references
		if (portAsset == null) //|| extraAsset == null)
			Debug.Log ("You did not assign the portasset in the inspector");

		// For every child transform under portasset, find the button and add onclick
		int i = 0;
//		
		foreach (Transform t in portAsset) {
			
			int currentIndex = i;

			Button b = t.GetComponent<Button>();
			b.onClick.AddListener (() => OnPortAssetSelect (currentIndex));

			//Set the colour of the button based on if own or not
			Image img = t.GetComponent<Image>();
			img.color = SaveManager.Instance.IsPortAssetOwned (i) ? Color.white : new Color (0.7f, 0.7f, 0.7f);

			i++;
		}

		//reset index
		i =0;

		//do the same for extra asset panel
//		foreach (Transform t in extraAsset) {
//
//			int currentIndex = i;
//
//			Button b = t.GetComponent<Button>();
//			b.onClick.AddListener (() => OnExtraAssetSelect (currentIndex));
//
//			//Set the colour of the button based on if own or not
//			Image img = t.GetComponent<Image>();
//			img.color = SaveManager.Instance.IsExtraAssetOwned (i) ? Color.white : new Color (0.7f, 0.7f, 0.7f);
//
//			i++;
//		}

	}

	private void NavigateTo (int menuIndex) {
		switch (menuIndex) {

		// 0 && default case = main menu
		default:
		case 0: 
			desiredMenuPosition = Vector3.zero;
			break;
		// 1 = Shop Menu
		case 1: 
			desiredMenuPosition = Vector3.left * 1280;
			break;
		}
	}

	private void SetPortAsset(int index){

		//set the active index
		activePortAssetIndex = index;
		SaveManager.Instance.state.activePortAsset = index;

		//change the  port asset on the player model
//		if (index == 0) {
//			LoadNotifs.Instance.truckOne.gameObject.SetActive (true);
//		} else if (index == 1){
//			LoadNotifs.Instance.quayTwo.gameObject.SetActive (true);
//		} else if (index == 2) {
//			LoadNotifs.Instance.yardCraneOne.gameObject.SetActive (true);
//		}

		//change buy/set button text
		portAssetBuySet.text = "Current";

		//Remeber preference
		SaveManager.Instance.Save();

	}


//	private void SetExtraAsset (int index) {
//
//		//set the active index
//		activeExtraAssetIndex = index;
//		SaveManager.Instance.state.activeExtraAsset = index;
//
//		//change the extra asset on the player model
//
//		//change buy/set button text
//		extraAssetBuySet.text = "Current";
//
//		//Remeber preference
//		SaveManager.Instance.Save();
//	}

	private void UpdateGoldText(){
		goldText.text = SaveManager.Instance.state.gold.ToString ("#");
		SaveManager.Instance.Save ();
		SaveManager.Instance.Load ();
	}


	//buttons
	public void OnPlayClick (string MainPage) {
		Debug.Log ("Play button has been clicked!");
		Application.LoadLevel (MainPage);
	}

	public void OnShopClick() {
		NavigateTo (1);
		Debug.Log ("Shop button has been clicked!");

	}

	private void OnPortAssetSelect (int currentIndex) {
		Debug.Log ("Selecting port asset : " + currentIndex);

		//iff the button clicked is already selected, exit
		if (selectedPortAssetIndex == currentIndex)
			return;

		//if it's not selected, make the icon slightly bigger
		portAsset.GetChild(currentIndex).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;
		//put the previous button back to normal
		portAsset.GetChild(selectedPortAssetIndex).GetComponent<RectTransform>().localScale = Vector3.one;

		//set the selected colour
		selectedPortAssetIndex = currentIndex;

		//change the content of the buy/set button, depending on state of the port asset
		if (SaveManager.Instance.IsPortAssetOwned(currentIndex)) {

			//port asset is owned
			//Is it already our current asset?
			if (activePortAssetIndex == currentIndex) {
				portAssetBuySet.text = "Current";
			} else {

				portAssetBuySet.text = "Select";
			}
		}

		else {
			//port asset isn't owned
			portAssetBuySet.text = "Buy: " +portAssetCost[currentIndex].ToString("F0");

				
			}
	}

//	private void OnExtraAssetSelect (int currentIndex) {
//		Debug.Log ("Selecting extra asset : " + currentIndex);
//
//		//iff the button clicked is already selected, exit
//		if (selectedExtraAssetIndex == currentIndex)
//			return;
//
//		//if it's not selected, make the icon slightly bigger
//		extraAsset.GetChild(currentIndex).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;
//		//put the previous button back to normal
//		extraAsset.GetChild(selectedExtraAssetIndex).GetComponent<RectTransform>().localScale = Vector3.one;
//
//
//		//set the selected colour
//		selectedExtraAssetIndex = currentIndex;
//
//		//change the content of the buy/set button, depending on state of the extra asset
//		if (SaveManager.Instance.IsExtraAssetOwned(currentIndex)) {
//
//			//extra asset is owned
//			//Is it already our current asset?
//			if (activeExtraAssetIndex == currentIndex) {
//				extraAssetBuySet.text = "Current";
//			} else {
//
//				extraAssetBuySet.text = "Select";
//			}
//		}
//
//		else {
//			//extra asset isn't owned
//			extraAssetBuySet.text = "Buy: " +extraAssetCost[currentIndex].ToString();
//
//
//		}
//	}

	public void OnPortAssetBuySet() {
		Debug.Log ("Buy/Set Port Asset");

		//is the selected colour owned
		if (SaveManager.Instance.IsPortAssetOwned (selectedPortAssetIndex)) {
			//set the colour
			SetPortAsset (selectedPortAssetIndex);
		} else {
			//attempt to buy port asset
			if (SaveManager.Instance.BuyPortAsset (selectedPortAssetIndex, portAssetCost [selectedPortAssetIndex])) {

				//Sucess
				SetPortAsset (selectedPortAssetIndex);

				//Change the color of the button
				portAsset.GetChild(selectedPortAssetIndex).GetComponent<Image>().color = Color.white; 

				UpdateGoldText ();

			} else {

				//do not have enough gold
				portAssetBuySet.text = "Not enough money!";
				Debug.Log("Not enough gold");

			}
		}
	}

//	public void OnExtraAssetBuySet(){
//		Debug.Log ("Buy/Set Extra Asset");
//
//		//is the selected colour owned
//		if (SaveManager.Instance.IsExtraAssetOwned (selectedExtraAssetIndex)) {
//			//set the colour
//			SetExtraAsset (selectedExtraAssetIndex);
//		} else {
//			//attempt to buy port asset
//			if (SaveManager.Instance.BuyExtraAsset (selectedExtraAssetIndex, extraAssetCost [selectedExtraAssetIndex])) {
//
//
//				//Sucess
//				SetExtraAsset (selectedExtraAssetIndex);
//
//				//Change the color of the button
//				extraAsset.GetChild(selectedExtraAssetIndex).GetComponent<Image>().color = Color.white; 
//
//				UpdateGoldText ();
//
//			} else {
//				//do not have enough gold
//				Debug.Log("Not enough gold");
//
//			}
//		}
//	}

	public void OnBackClick () {
		NavigateTo (0);
		Debug.Log ("Back button has been clicked.");
	}
}
