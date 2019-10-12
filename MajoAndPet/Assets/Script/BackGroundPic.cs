using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//背景を保存する
public class BackGroundPic : MonoBehaviour {
    public static BackGroundPic AccsBack;

    public Sprite[] BackGroundSprite;
    public Image BGpic;
    
    private bool Called = false;

    void Awake()
    {
        AccsBack = this;
    }
	void Start () {
        BGpic = gameObject.GetComponent<Image>();
        BGpic.sprite = BackGroundSprite[2];

	}

  
}
