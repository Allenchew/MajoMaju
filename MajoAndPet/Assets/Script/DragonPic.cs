using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonPic : MonoBehaviour {
    public static DragonPic MobPics;
    public Sprite[] DragonSprite;

    private EnshitsuFunc MobEnshitsu = new EnshitsuFunc();
    private Image CurrentDragon;
    private bool Fading = false;
	void Start () {
        MobPics = this;
        CurrentDragon = transform.GetComponent<Image>();
	}
}
