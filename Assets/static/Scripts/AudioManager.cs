using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour {

    public AudioSource BGM;
    public Button SoundButton;
    public Sprite SoundOn;
    public Sprite SoundOff;
    public int SoundCounter = 1;

    public static AudioManager Instance;
	// Use this for initialization
	void Start () {

         if (Instance == null)
         {
             Instance = this;
             DontDestroyOnLoad(gameObject);
         }else if (Instance != this)
         {
             Destroy(gameObject);
         }
        //DontDestroyOnLoad(gameObject);

        //SoundButton = GetComponent<Button>();

    }

  //  public void resetSound

    public void changeButton()
    {
        SoundCounter++;
        if (SoundCounter % 2 == 0)
        {
            //SoundButton.image.overrideSprite = SoundOn;
            SoundButton.GetComponentInChildren<Image>().sprite = SoundOn;

        }
        else
        {
           // SoundButton.image.overrideSprite = SoundOff;
            SoundButton.GetComponentInChildren<Image>().sprite = SoundOff;

        }
    }

    public void MuteSound()
    {
         AudioListener.pause = !AudioListener.pause;
        //AudioListener.pause = true; 
    }

    public void PlaySound()
    {
       // AudioListener.pause = !AudioListener.pause;
        AudioListener.pause = false;
    }

    // Update is called once per frame
  

    public void ChangeBGM(AudioClip music)
    {
        if (BGM.clip.name == music.name)
            return;

        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }

    


}
