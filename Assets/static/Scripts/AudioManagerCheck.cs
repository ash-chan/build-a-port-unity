using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagerCheck : MonoBehaviour
{
    public Button muteUnmuteButton;
    public GameObject audioMan;
    public Sprite mutePic;
    public Sprite unMutePic;

    // Use this for initialization
    void Start()
    {
        if (FindObjectOfType<AudioManager>())
            return;
        else
            Instantiate(audioMan, transform.position, transform.rotation);


    }

    // Update is called once per frame
    void Update()
    { }

    public void onPressMute()
    {
        AudioListener.pause = !AudioListener.pause;
		if (AudioListener.pause) {
			muteUnmuteButton.GetComponentInChildren<Image> ().sprite = mutePic;
		} else {
			muteUnmuteButton.GetComponentInChildren<Image> ().sprite = unMutePic;
		}
    }
}