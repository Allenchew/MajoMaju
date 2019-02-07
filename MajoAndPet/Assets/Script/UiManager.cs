using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {
    public Sprite[] UiImage;
    public GameObject[] GameUi;

    private bool preset = false;
    private Sprite[][] UiToUse=new Sprite[2][] { new Sprite[4], new Sprite[4]};
	void Start () {
        int k = 0;
		for(int i = 0; i < 2; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                UiToUse[i][j] = UiImage[k];
                k++;
            }
        }
	}

	void Update () {
	    if(preset)
        {
            preset = false;
            for(int i = 0; i < 4; i++)
            {
                GameUi[i].GetComponent<Image>().sprite = UiToUse[(int)ScenarioManager.SceneMngIns.SType][i];
            }
        }
	}
    
    public void SetPreset()
    {
        preset = true;
    }
}
