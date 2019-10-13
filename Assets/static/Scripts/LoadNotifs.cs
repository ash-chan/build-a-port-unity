using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNotifs : MonoBehaviour
{
	public static LoadNotifs Instance { set; get; }

    public string NotifSceneForDeliveryDash;
	public string NotifSceneForEvacuateTheCrate1;
	public string NotifSceneForEvacuateTheCrate2;
	public string NotifSceneForEvacuateTheCrate3;
	public string NotifSceneForCrateTower;
	public GameObject quayTwo;
	public GameObject truckOne;
	public GameObject yardCraneOne;
    
    public float delayBeforeLoading;

    private float timeElapsed;

	int SceneNumberToBeCalled;

    private void Start()
    {
        AudioListener.pause = false;
		quayTwo.gameObject.SetActive (SaveManager.Instance.state.quaytwo);
		truckOne.gameObject.SetActive (SaveManager.Instance.state.truckOne);
		yardCraneOne.gameObject.SetActive (SaveManager.Instance.state.yardCraneOne);
    }


    // Update is called once per frame
    private void Update()
    { 
		SceneNumberToBeCalled = Random.Range(1,10);

		for (int i = 0; i < 1; i++) {
			timeElapsed += Time.deltaTime;

			if (timeElapsed > delayBeforeLoading) {
				Money.inPort = false;    
		
				switch (SceneNumberToBeCalled) {
				case 1:
					SceneManager.LoadScene (NotifSceneForDeliveryDash);
					Debug.Log ("DeliveryDash");
					break;
				case 2:
					SceneManager.LoadScene (NotifSceneForDeliveryDash);
					Debug.Log ("DeliveryDash");
					break;
				case 3:	
					SceneManager.LoadScene (NotifSceneForDeliveryDash);
					Debug.Log ("DeliveryDash");
					break;
				case 4:
					SceneManager.LoadScene (NotifSceneForEvacuateTheCrate1);
					Debug.Log ("Evacuate1");
					break;
				case 5:
					SceneManager.LoadScene (NotifSceneForEvacuateTheCrate2);
					Debug.Log ("Evacuate2");
					break;
				case 6: 
					SceneManager.LoadScene (NotifSceneForEvacuateTheCrate3);
					Debug.Log ("Evacuate3");
					break;
				case 7:
					SceneManager.LoadScene (NotifSceneForCrateTower);
					Debug.Log ("CrateTower");
					break;
				case 8:
					SceneManager.LoadScene (NotifSceneForCrateTower);
					Debug.Log ("CrateTower");
					break;
				case 9:	
					SceneManager.LoadScene (NotifSceneForCrateTower);
					Debug.Log ("CrateTower");
					break;
				}
              
			}
		}
	 }
}