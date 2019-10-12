using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//グリフォンの画像を保存する
public class GryphonPic : MonoBehaviour {
    public static GryphonPic MobPics;
    public Sprite[] GryphonSprite;

    private EnshitsuFunc MobEnshitsu = new EnshitsuFunc();
    private Image CurrentGryphon;
    private bool Fading = false;
    void Awake()
    {
        MobPics = this;
    }
    void Start()
    {
       
        CurrentGryphon = transform.GetComponent<Image>();
    }
}
