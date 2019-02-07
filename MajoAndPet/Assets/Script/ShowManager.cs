using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowManager : MonoBehaviour {
    public static ShowManager ItsShow;
    public GameObject Box;
    public GameObject Letter;
    public GameObject MobChar;
    public Image BackGround;
    public Sprite EndScene;
    public Camera cam;
    
    public Sprite[] BoxPic;
    public Sprite[] MaoPic;
    public Sprite[] Kpic;
    public Sprite[] SuchiruPic;

    [System.NonSerialized]
    public bool AnimDelay = true;

    private EnshitsuFunc BoxEnshitsu = new EnshitsuFunc();
    private bool initMove = true;
    private int boxPicIndex = 0;
    private Vector2 OrgSize;
    private Vector3 OrgPos;
    private int stepper = 0;
    void Start()
    {
        ItsShow = this;
    }

    void Update()
    {
    }
    
}
