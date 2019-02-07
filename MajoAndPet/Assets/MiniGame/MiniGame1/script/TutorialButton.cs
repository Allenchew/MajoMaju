using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour {
    public static bool TriggerStart = false;

    public GameObject nextB;
    public GameObject backB;
    public GameObject confirmB;
    public GameObject firstPic;
    public GameObject secondPic;
    // Use this for initialization
    void Start () {
		
	}
	
	void Update () {
		
	}
    public void nextButton()
    {
        nextB.SetActive(false);
        backB.SetActive(true);
        confirmB.SetActive(true);
        firstPic.SetActive(false);
        secondPic.SetActive(true);
    }    
    public void backButton()
    {
        backB.SetActive(false);
        confirmB.SetActive(false);
        nextB.SetActive(true);
        firstPic.SetActive(true);
        secondPic.SetActive(false);
    }
    public void confirmButton()
    {
        gameObject.SetActive(false);
        TriggerStart = true;
    }
}
