using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour {
    
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            SoundMnger.SoundInstance.NextScene = "main";
            SceneManager.LoadScene("main");
        }
    }
}
