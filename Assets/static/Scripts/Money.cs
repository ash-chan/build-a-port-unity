using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Money : MonoBehaviour {

	public Text moneyText;
	public static float currentMoney = 0;
	public float increasePerSecond = 20;
    public static bool inPort = true;

	public static Money Instance;

    void Awake()
    {
//		if (Instance == null) {
//			Instance = this;
//			DontDestroyOnLoad(transform.gameObject);
//		} else if (Instance != this) {
//			Destroy (gameObject);
//		}
			

        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start () {
		

	}

	private void Update () {
        //InvokeRepeating ("EarnMoney", 0, 10f);


        Debug.Log(currentMoney);
        if (inPort == true)
        {
            EarnMoney();
            if (currentMoney < 10000)
                moneyText.text =  currentMoney.ToString("#");
            else
                moneyText.text =  (currentMoney / 1000).ToString("F2") + " K";
        }

	}

	private void EarnMoney() {
		currentMoney = Mathf.Clamp (currentMoney + increasePerSecond * Time.deltaTime, 0, 99999999);
	}
}
