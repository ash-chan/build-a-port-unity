using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoader : MonoBehaviour {

	private CanvasGroup fadeGroup;
	private float loadTime;
	private float minimumLogoTime = 3.0f; //Minimum time of that scene


	private void Start () {
		//Grab the only CanvasGroup in the scene
		fadeGroup = FindObjectOfType<CanvasGroup>();

		//Start with white screen
		fadeGroup.alpha = 1;

		//Pre Load the game
		//$$ no game

		//Get a timestamp of completion time
		//if loadtime is short, give it a small buffer time so we can appreciate the logo
		if (Time.time < minimumLogoTime)
			loadTime = minimumLogoTime;
		else
			loadTime = Time.time;
	}

	private void Update ()
	{
		//Fade-in
		if (Time.time < minimumLogoTime) {
			fadeGroup.alpha = 1 - Time.time;
		}

		//Fade-out
		if(Time.time > minimumLogoTime && loadTime!=0)
		{
			fadeGroup.alpha = Time.time - minimumLogoTime;
			if (fadeGroup.alpha >= 1) 
			{
				SceneManager.LoadScene("Menu");
			}
		}

	}
}
	

