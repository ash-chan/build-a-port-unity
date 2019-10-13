using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

	public static SaveManager Instance { set; get; }
	public SaveState state;


	private void Awake () {

		//ResetSave ();

		DontDestroyOnLoad (gameObject);
		Instance = this;
		Load ();


	}

	// Save the whole state of this SaveState script to the player pref
	public void Save() {
		PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
	}

	//Load the previous saved state from the player prefs
	public void Load()
	{
		//Do we already have a save?
		if (PlayerPrefs.HasKey ("save")) {
			state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
	
		} else {
			state = new SaveState();
			Save ();
			Debug.Log ("No save file found, creating a new one");
		}
	}

	public void updateCash(float currentmoney){
		state.gold += currentmoney;
		Save ();
	}

	//check if port asset has already been bought
	public bool IsPortAssetOwned (int index) {

		//check if the bit is set, if so the port asset is owned
		return (state.portAssetOwned & (1<<index)) != 0;

	}

	//check if extra asset has already been bought
//	public bool IsExtraAssetOwned (int index) {
//
//		//check if the bit is set, if so the extra asset is owned
//		return (state.extraAssetOwned & (1<<index)) != 0;
//
//	}


	//attempt buying port asset
	public bool BuyPortAsset(int index, int cost) {
		if (state.gold >= cost) {
			//enough money, remove from the current gold stack
			state.gold -= cost;
			UnlockPortAsset (index);

			if (index == 0) {
				state.truckOne = true;
				Save ();
			} else if (index == 1){
				state.quaytwo = true;
				Save ();

			} else if (index == 2) {
				state.yardCraneOne = true;
				Save ();
			}

			//save progress
			Save ();

			return true;
		} else {
			//not enough money, return false
			return false;
		}
	}


	//attempt buying extra asset
//	public bool BuyExtraAsset(int index, int cost) {
//		if (state.gold >= cost) {
//			//enough money, remove from the current gold stack
//			state.gold -= cost;
//			UnlockExtraAsset (index);
//
//			//save progress
//			Save ();
//
//			return true;
//		} else {
//			//not enough money, return false
//			return false;
//		}
//	}

	//unlock a port asset in the "portAssetOwned" int
	public void UnlockPortAsset (int index) {

		//toggle on the bit at index
		state.portAssetOwned |= 1<<index;
	}


	//unlock a extra asset in the "extraAssetOwned" int
//	public void UnlockExtraAsset (int index) {
//
//		//toggle on the bit at index
//		state.extraAssetOwned |= 1<<index;
//	}
//
//	//resets the whole save file
	public void ResetSave() {
		PlayerPrefs.DeleteKey ("save");
	}
}
