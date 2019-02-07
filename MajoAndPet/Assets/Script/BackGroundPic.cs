using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackGroundPic : MonoBehaviour {
    public static BackGroundPic AccsBack;

    public Sprite[] BackGroundSprite;
    public Image BGpic;
    
    private bool Called = false;
	// Use this for initialization
    void Awake()
    {
        AccsBack = this;
    }
	void Start () {
        
        BGpic = gameObject.GetComponent<Image>();
        BGpic.sprite = BackGroundSprite[2];

	}
	void Update () {
		
	}
  
}
