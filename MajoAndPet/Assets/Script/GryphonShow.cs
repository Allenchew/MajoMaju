using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//グリフォンの演出処理
public class GryphonShow : MonoBehaviour {
    public static GryphonShow showGryphon;

    #region 初期化
    public GameObject Gryphon;
    public GameObject Box;
    public GameObject BackGround;
    public GameObject Letter;
    public GameObject Mao;
    public GameObject Food;
    public GameObject ScreenMask;
    public GameObject Suchiru;
    public GameObject MiddleBar;
    public GameObject preBack;
    public GameObject whiteScreen;
    public GameObject Tornado;
    public bool Showing = true;
    public bool AnimDelay = true;

    private Vector3[] _initPos = new Vector3[3];
    private Vector2[] _initSize = new Vector2[3];
    private int _showIndex = 0;
    private bool vocalOnly = false;
    private int vocalOnlyIndex = 0;


    void Awake()
    {
        showGryphon = this;
    }

    void Start () {
        var tempEnshitsu = GameObject.FindGameObjectWithTag("Enshitsu").transform;
        preBack = tempEnshitsu.GetChild(0).gameObject;
        Box = tempEnshitsu.GetChild(3).gameObject;
        Gryphon = tempEnshitsu.GetChild(4).gameObject;
        Letter = tempEnshitsu.GetChild(5).gameObject;
        BackGround = tempEnshitsu.GetChild(1).gameObject;
        Mao = tempEnshitsu.GetChild(6).gameObject;
        Food = tempEnshitsu.GetChild(7).gameObject;
        MiddleBar = tempEnshitsu.GetChild(8).gameObject;
        Suchiru = tempEnshitsu.GetChild(9).gameObject;
        _initPos[0] = Box.transform.localPosition;
        _initSize[0] = Box.GetComponent<RectTransform>().sizeDelta;
        _initPos[1] = Gryphon.transform.localPosition;
        _initSize[1] = Gryphon.GetComponent<RectTransform>().sizeDelta;
        _initPos[2] = Food.transform.localPosition;
        _initSize[2] = Food.GetComponent<RectTransform>().sizeDelta;
        BackGround.GetComponent<Image>().material.SetFloat("_EffectAmount", 0);
    }
    #endregion

    //演出を順番通りに実行する
    public void CallShow()
    {
        if (vocalOnly)　//音声処理
        {
            switch (vocalOnlyIndex)
            {
                case 0:
                    //5 -2
                    SoundMnger.SoundInstance.GetGryphonVocal(2);
                    vocalOnly = false;
                    break;
                case 1:
                    //13 +3
                    SoundMnger.SoundInstance.GetGryphonVocal(3);
                    vocalOnly = false;
                    break;
                case 2:
                    //14 +1
                    SoundMnger.SoundInstance.GetGryphonVocal(0);
                    vocalOnly = false;
                    break;
                case 3:
                    //27 -1
                    SoundMnger.SoundInstance.GetGryphonVocal(3);
                    vocalOnly = false;
                    break;
                case 4:
                    //34 +1
                    SoundMnger.SoundInstance.GetGryphonVocal(10);
                    vocalOnly = false;
                    break;
                case 5:
                    //36 +1
                    SoundMnger.SoundInstance.GetGryphonVocal(5);
                    vocalOnly = false;
                    break;
                case 6:
                    //42 +1
                    SoundMnger.SoundInstance.GetGryphonVocal(10);
                    vocalOnly = false;
                    break;
                case 7:
                    //44 -1
                    SoundMnger.SoundInstance.GetGryphonVocal(12);
                    vocalOnly = false;
                    break;
                case 8:
                    //60-1
                    SoundMnger.SoundInstance.GetGryphonVocal(5);
                    vocalOnly = false;
                    break;
                case 9:
                    //66 -3
                    SoundMnger.SoundInstance.GetGryphonVocal(9);
                    vocalOnly = false;
                    break;
                case 10:
                    //66 +2
                    SoundMnger.SoundInstance.GetGryphonVocal(11);
                    vocalOnly = false;
                    break;
                case 11:
                    //70+1
                    SoundMnger.SoundInstance.GetGryphonVocal(14);
                    vocalOnly = false;
                    break;
                case 12:
                    //87 +1
                    SoundMnger.SoundInstance.GetGryphonVocal(11);
                    vocalOnly = false;
                    break;
                case 13:
                    //88 +1
                    SoundMnger.SoundInstance.GetGryphonVocal(18);
                    vocalOnly = false;
                    break;
                case 14:
                    //90+1
                    SoundMnger.SoundInstance.GetGryphonVocal(19);
                    vocalOnly = false;
                    break;
                case 15:
                    //91 +2
                    SoundMnger.SoundInstance.GetGryphonVocal(20);
                    break;
                case 16:
                    //91 +3
                    SoundMnger.SoundInstance.GetGryphonVocal(21);
                    break;
                case 17:
                    //91+5
                    SoundMnger.SoundInstance.GetGryphonVocal(22);
                    break;
                case 18:
                    //93 -4
                    SoundMnger.SoundInstance.GetGryphonVocal(23);
                    vocalOnly = false;
                    break;
            }
            vocalOnlyIndex++;
        }
        else {
            Debug.Log(_showIndex);
            switch (_showIndex)　//画面処理
            {
                case 0:
                    _changePic(ScreenMask, null);
                    StartCoroutine(_changeColor(ScreenMask, Color.black, Color.clear, 0.03f, true));
                    SoundMnger.SoundInstance.GetBgmPlay(0);
                    StartCoroutine(delayRun(3.0f, () => { ScenarioManager.SceneMngIns.StartPrint = true; ScenarioManager.SceneMngIns.Once = true; }));
                    break;
                case 1:
                    Box.SetActive(true);
                    StartCoroutine(PopOut(Box, true));
                    break;
                case 2:
                    SoundMnger.SoundInstance.GetSePlay(16);
                    SoundMnger.SoundInstance.GetGryphonVocal(2);
                    break;
                case 3:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    _changePic(Box, ShowManager.ItsShow.BoxPic[1]);
                    _setInit(Box, 0);
                    StartCoroutine(PopOut(Box, false));

                    SoundMnger.SoundInstance.GetSePlay(1);
                    StartCoroutine(delayRun(2.0f, () => { Gryphon.SetActive(true); _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[0]); }));
                    break;
                case 4:
                    StartCoroutine(_changeColor(Box, Color.white, Color.clear, 0.01f, false));
                    SoundMnger.SoundInstance.GetGryphonVocal(0);
                    ScenarioManager.SceneMngIns.StartPrint = true;
                    vocalOnly = true;
                    break;
                case 5:
                    _setColor(Gryphon, Color.white, Color.grey);
                    break;
                case 6:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    Letter.SetActive(true);
                    StartCoroutine(PopOut(Letter, false));
                    break;
                case 7:
                    SoundMnger.SoundInstance.GetScaling(false);
                    Gryphon.SetActive(false);
                    StartCoroutine(_changeColor(BackGround, new Color(0.25f, 0.25f, 0.25f, 1), Color.black, 0.01f, false));
                    Letter.SetActive(false);
                    SoundMnger.SoundInstance.GetSePlay(17);
                    ScenarioManager.SceneMngIns.StartPrint = true;
                    break;
                case 8:
                    Mao.SetActive(true);
                    _changePic(Mao, ShowManager.ItsShow.MaoPic[2]);
                    SoundMnger.SoundInstance.GetBgmPlay(1);
                    SoundMnger.SoundInstance.GetScaling(true);
                    break;
                case 9:
                    _changePic(Mao, ShowManager.ItsShow.MaoPic[1]);
                    break;
                case 10:
                    _changePic(Mao, ShowManager.ItsShow.MaoPic[2]);
                    break;
                case 11:
                    Mao.SetActive(false);
                    break;
                case 12:
                    SoundMnger.SoundInstance.GetScaling(false);
                    StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0.01f, false));
                    break;
                case 13:
                    Gryphon.SetActive(true);
                    _setColor(Gryphon, Color.grey, Color.white);
                    SoundMnger.SoundInstance.GetScaling(true);
                    SoundMnger.SoundInstance.GetBgmPlay(0);
                    SoundMnger.SoundInstance.GetGryphonVocal(0);
                    vocalOnly = true;
                    break;
                case 14:
                    SoundMnger.SoundInstance.GetSePlay(8);
                    StartCoroutine(_changeSize(Gryphon, (1f / 0.7f)));
                    vocalOnly = true;
                    break;
                case 15:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    SoundMnger.SoundInstance.GetScaling(false);
                    Gryphon.SetActive(false);
                    StartCoroutine(_turnDark(() => { ScenarioManager.SceneMngIns.StartPrint = true; ScenarioManager.SceneMngIns.Once = true; }));
                    break;
                case 16:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    _setColor(BackGround, Color.white, Color.black);
                    StartCoroutine(_changeColor(ScreenMask, Color.black, Color.clear, 0.03f, true));
                    StartCoroutine(delayRun(3.0f, () => { ScenarioManager.SceneMngIns.StartPrint = true; }));
                    break;
                case 17:
                    _changePic(BackGround, BackGroundPic.AccsBack.BackGroundSprite[0]);
                    StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0.01f, false));
                    SoundMnger.SoundInstance.GetScaling(true);
                    SoundMnger.SoundInstance.GetBgmPlay(6);
                    SoundMnger.SoundInstance.GetSePlay(18);
                    break;
                case 18:
                    Gryphon.SetActive(true);
                    break;
                case 19:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    _setColor(Gryphon, Color.white, Color.grey);
                    StartCoroutine(_changeSize(Gryphon, 0.7f));
                    SoundMnger.SoundInstance.GetSePlay(19);
                    StartCoroutine(_soundProcedure(20, () => { ScenarioManager.SceneMngIns.StartPrint = true; }));
                    break;
                case 20:
                    _setColor(Gryphon, Color.grey, Color.white);
                    StartCoroutine(_changeSize(Gryphon, 1f / 0.7f));
                    break;
                case 21:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    _changePic(Food, ShowManager.ItsShow.BoxPic[2]);
                    Food.SetActive(true);
                    StartCoroutine(PopOut(Food, false));
                    StartCoroutine(delayRun(1.0f, () => { ScenarioManager.SceneMngIns.StartPrint = true; }));
                    break;
                case 22:
                    Food.SetActive(false);
                    Gryphon.SetActive(true);
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[1]);
                    break;
                case 23:
                    _setColor(Gryphon, Color.white, Color.grey);
                    break;
                case 24:
                    _setColor(Gryphon, Color.grey, Color.white);
                    break;
                case 25:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[0]);
                    SoundMnger.SoundInstance.GetGryphonVocal(1);
                    break;
                case 26:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[1]);
                    SoundMnger.SoundInstance.GetGryphonVocal(3);
                    vocalOnly = true;
                    break;
                case 27:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[0]);
                    StartCoroutine(_doubleTeam());
                    SoundMnger.SoundInstance.GetSePlay(19);
                    break;
                case 28:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[1]);
                    SoundMnger.SoundInstance.GetGryphonVocal(0);
                    break;
                case 29:
                    Gryphon.SetActive(false);
                    StartCoroutine(_changeColor(BackGround, Color.white, Color.black, 0.01f, false));
                    break;
                case 30:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    ScreenMask.SetActive(true);
                    StartCoroutine(_turnDark(() => { ScenarioManager.SceneMngIns.StartPrint = true; ScenarioManager.SceneMngIns.Once = true; }));
                    break;
                case 31:
                    StartCoroutine(_changeColor(ScreenMask, Color.black, Color.clear, 0.03f, true));
                   
                    break;
                case 32:
                    _changePic(BackGround, BackGroundPic.AccsBack.BackGroundSprite[2]);
                    StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0.01f, false));
                    SoundMnger.SoundInstance.GetSePlay(21);
                    break;
                case 33:
                    SoundMnger.SoundInstance.GetSePlay(22);
                    Gryphon.SetActive(true);
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[4]);
                    StartCoroutine(_changeSize(Gryphon, 1.0f / 0.7f));
                    SoundMnger.SoundInstance.GetGryphonVocal(6);
                    break;
                case 34:
                    SoundMnger.SoundInstance.GetScaling(true);
                    SoundMnger.SoundInstance.GetBgmPlay(7);
                    vocalOnly = true;
                    break;
                case 35:
                    _setColor(Gryphon, Color.white, Color.grey);
                    break;
                case 36:
                    _setColor(Gryphon, Color.grey, Color.white);
                    vocalOnly = true;
                    break;
                case 37:
                    _setColor(Gryphon, Color.white, Color.grey);
                    break;
                case 38:
                    _setColor(Gryphon, Color.grey, Color.white);
                    break;
                case 39:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[2]);
                    SoundMnger.SoundInstance.GetGryphonVocal(6);
                    break;
                case 40:
                    SoundMnger.SoundInstance.GetScaling(false);
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[3]);
                    SoundMnger.SoundInstance.GetGryphonVocal(12);
                    break;
                case 41:
                    StartCoroutine(_soundProcedure(23, () => { StartCoroutine(_changeSize(Gryphon, 0.7f)); SoundMnger.SoundInstance.GetSePlay(19); }));
                    break;
                case 42:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[4]);
                    vocalOnly = true;
                    break;
                case 43:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[3]);
                    vocalOnly = true;
                    break;
                case 44:
                    Gryphon.SetActive(false);
                    SoundMnger.SoundInstance.GetSePlay(19);
                    StartCoroutine(_soundProcedure(24, () => { SoundMnger.SoundInstance.GetSePlay(25); }));

                    break;
                case 45:
                    StartCoroutine(_changeColor(BackGround, Color.white, Color.black, 0.01f, false));
                    break;
                case 46:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    ScreenMask.SetActive(true);
                    StartCoroutine(_turnDark(() => { StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0.0f, false)); ScenarioManager.SceneMngIns.StartPrint = true; ScenarioManager.SceneMngIns.Once = true; }));
                    break;
                case 47:
                    _changePic(BackGround, BackGroundPic.AccsBack.BackGroundSprite[6]);
                    StartCoroutine(_changeColor(ScreenMask, Color.black, Color.clear, 0.03f, true));
                 
                    SoundMnger.SoundInstance.GetScaling(true);
                    SoundMnger.SoundInstance.GetBgmPlay(8);
                    StartCoroutine(delayRun(3.0f, () => { SoundMnger.SoundInstance.GetSePlay(26); }));
                    break;
                case 48:
                    Tornado.SetActive(true);
                    SoundMnger.SoundInstance.GetSePlay(27);
                    StartCoroutine(delayRun(1.5f, () => { Tornado.SetActive(false); }));
                    break;
                case 49:
                    SoundMnger.SoundInstance.GetSePlay(26);
                    break;
                case 50:
                    _changePic(whiteScreen, BackGroundPic.AccsBack.BackGroundSprite[7]);
                    StartCoroutine(_changeColor(whiteScreen, Color.clear, Color.white, 0.02f, false));
                    StartCoroutine(delayRun(2.0f, () => { _changePic(BackGround, BackGroundPic.AccsBack.BackGroundSprite[7]);
                        whiteScreen.SetActive(false);
                        _changePic(whiteScreen, null);
                        StartCoroutine(_flashScreen(whiteScreen, Color.black));
                        StartCoroutine(_soundProcedure(28, () => { }));
                    }));
                    break;
                case 51:
                    _changePic(preBack, BackGroundPic.AccsBack.BackGroundSprite[6]);
                    preBack.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                    preBack.transform.localPosition = new Vector3(470, -380, 0);
                    StartCoroutine(_flashScreen(whiteScreen, Color.black));
                    StartCoroutine(_soundProcedure(28, () => { StartCoroutine(_changeColor(BackGround, Color.white, Color.clear, 0.01f, false)); SoundMnger.SoundInstance.GetSePlay(10); }));
                    break;
                case 52:
                    StartCoroutine(_flashScreen(whiteScreen, Color.black));
                    StartCoroutine(_soundProcedure(29, () => { }));
                    break;
                case 53:
                    SoundMnger.SoundInstance.GetSePlay(30);
                    StartCoroutine(_soundProcedure(31, () => { }));
                    break;
                case 54:
                    StartCoroutine(_enshitsuK(3));
                    StartCoroutine(delayRun(3.0f,()=> { StartCoroutine(EnshitsuE());}));
                    break;
                case 55:
                    SoundMnger.SoundInstance.StopBgm();
                    StartCoroutine(_changeColor(BackGround, Color.white, Color.black, 0.01f, false));
                    SoundMnger.SoundInstance.GetSePlay(28);
                    break;
                case 56:
                    SoundMnger.SoundInstance.GetSePlay(32);
                    StartCoroutine(_soundProcedure(33, () => { SoundMnger.SoundInstance.GetSePlay(34); }));
                    break;
                case 57:
                    StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0.01f, false));
                    _changePic(BackGround, BackGroundPic.AccsBack.BackGroundSprite[6]);
                    SoundMnger.SoundInstance.GetScaling(true);
                    SoundMnger.SoundInstance.GetBgmPlay(4);
                    Gryphon.SetActive(true);
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[3]);
                    break;
                case 58:
                    SoundMnger.SoundInstance.GetSePlay(35); //699
                    break;
                case 59:
                    vocalOnly = true;
                    StartCoroutine(_changeSize(Gryphon, 1.0f / 0.7f));
                    SoundMnger.SoundInstance.GetGryphonVocal(6);
                    break;
                case 60:
                    SoundMnger.SoundInstance.GetSePlay(36);
                    break;
                case 61:
                    Gryphon.SetActive(false);
                    StartCoroutine(_changeColor(BackGround, Color.white, Color.black, 0.03f, false));
                    break;
                case 62:
                    SoundMnger.SoundInstance.GetScaling(false);
                    _changePic(BackGround, BackGroundPic.AccsBack.BackGroundSprite[1]);
                    Gryphon.SetActive(true);
                    StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0.03f, false));
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[4]);
                    SoundMnger.SoundInstance.GetGryphonVocal(9);
                    break;
                case 63:
                    SoundMnger.SoundInstance.GetBgmPlay(5);
                    SoundMnger.SoundInstance.GetScaling(true);
                    break;
                case 64:
                    _setColor(Gryphon, Color.white, Color.grey);
                    break;
                case 65:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[2]);
                    _setColor(Gryphon, Color.grey, Color.white);
                    SoundMnger.SoundInstance.GetGryphonVocal(8);
                    vocalOnly = true;
                    break;
                case 66:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[4]);
                    vocalOnly = true;
                    break;
                case 67:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[2]);
                    break;
                case 68:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[4]);
                    SoundMnger.SoundInstance.GetGryphonVocal(16);
                    break;
                case 69:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[2]);
                    SoundMnger.SoundInstance.GetGryphonVocal(16);
                    break;
                case 70:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[5]);
                    SoundMnger.SoundInstance.GetGryphonVocal(8);
                    vocalOnly = true;
                    break;
                case 71:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[2]);
                    break;
                case 72:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[5]);
                    SoundMnger.SoundInstance.GetGryphonVocal(3);
                    break;
                case 73:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[2]);
                    SoundMnger.SoundInstance.GetGryphonVocal(16);
                    break;
                case 74:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[3]);
                    break;
                case 75:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[2]);
                    SoundMnger.SoundInstance.GetGryphonVocal(11);
                    break;
                case 76:
                    Gryphon.SetActive(false);
                    break;
                case 77:
                    SoundMnger.SoundInstance.GetScaling(false);
                    whiteScreen.SetActive(true);
                    StartCoroutine(_changeColor(whiteScreen, Color.clear, Color.white, 0.01f, false));
                    SoundMnger.SoundInstance.GetSePlay(9);
                    break;
                case 78:
                    StartCoroutine(_changeColor(whiteScreen, Color.white, Color.clear, 0.01f, false));
                    StartCoroutine(_changeSize(Gryphon, 0.7f));
                    Gryphon.transform.position = new Vector3(0, -150, 0);
                    StartCoroutine(delayRun(2.0f, () => { Gryphon.SetActive(true); }));
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[11]);
                    SoundMnger.SoundInstance.GetScaling(true);
                    SoundMnger.SoundInstance.GetBgmPlay(9);
                    break;
                case 79:
                    SoundMnger.SoundInstance.GetSePlay(22);
                    StartCoroutine(_repos(Gryphon, new Vector3(0, -400, 0)));
                    StartCoroutine(_changeSize(Gryphon, 1.0f / 0.7f));
                    break;
                case 80:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[9]);
                    SoundMnger.SoundInstance.GetGryphonVocal(7);
                    break;
                case 81:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[11]);
                    break;
                case 82:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[8]);
                    SoundMnger.SoundInstance.GetGryphonVocal(9);
                    break;
                case 83:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[10]);
                    SoundMnger.SoundInstance.GetGryphonVocal(15);
                    break;
                case 84:
                    Gryphon.SetActive(false);
                    break;
                case 85:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[6]);
                    StartCoroutine(_enshitsuI(preBack, new Vector3(0, 0, 0), new Vector3(1.6f, 1.6f, 1.6f)));
                    break;
                case 86:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[10]);
                    SoundMnger.SoundInstance.GetGryphonVocal(8);
                    break;
                case 87:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[11]);
                    vocalOnly = true;
                    break;
                case 88:
                    _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[9]);
                    SoundMnger.SoundInstance.GetGryphonVocal(17);
                    vocalOnly = true;
                    break;
                case 89:
                    SoundMnger.SoundInstance.GetScaling(false);
                    SoundMnger.SoundInstance.GetSePlay(37);
                    break;
                case 90:
                    Gryphon.SetActive(false);
                    SoundMnger.SoundInstance.GetScaling(true);
                    SoundMnger.SoundInstance.GetBgmPlay(3);
                    _changePic(Suchiru, ShowManager.ItsShow.SuchiruPic[1]);
                    StartCoroutine(_showSuchiru());
                    vocalOnly = true;
                    break;
                case 91:
                    ScreenMask.SetActive(true);
                    StartCoroutine(_flashScreen(ScreenMask, Color.black));
                    vocalOnly = true;
                    break;
                case 92:
                    SoundMnger.SoundInstance.GetSePlay(36);
                    break;
                case 93:
                    Gryphon.SetActive(false);
                    SoundMnger.SoundInstance.GetScaling(false);
                    _changePic(ScreenMask, ShowManager.ItsShow.EndScene);
                    StartCoroutine(_turnDark(() => { StartCoroutine(delayRun(3f, () => { SceneManager.LoadScene("title"); SoundMnger.SoundInstance.ReloadSound(); })); }));
                    break;
            }
            _showIndex++;
        }
    }

    #region 汎用関数
    IEnumerator PopOut(GameObject MovTarget, bool initMove)
    {
        AnimDelay = true;
        for (int i = 0; i < 4; i++)
        {
            MovTarget.GetComponent<RectTransform>().sizeDelta += new Vector2(100f, 100f);
            MovTarget.transform.position += new Vector3(0, 40f, 0);
            if (AnimDelay) yield return new WaitForSeconds(0.03f);
        }
        MovTarget.GetComponent<RectTransform>().sizeDelta -= new Vector2(100f, 100f);
        if (AnimDelay) yield return new WaitForSeconds(0.01f);
        MovTarget.GetComponent<RectTransform>().sizeDelta += new Vector2(100f, 100f);
        if (AnimDelay) yield return new WaitForSeconds(0.05f);

        float[] TempSet = new float[3];
        if (initMove)
        {
            TempSet[0] = 40;
            TempSet[1] = 0.02f;
            TempSet[2] = 60;
        }
        else
        {
            TempSet[0] = 10;
            TempSet[1] = 0.01f;
            TempSet[2] = 30;
        }
        for (int i = 0; i < 16; i++)
        {
            MovTarget.transform.position -= new Vector3(0, TempSet[0], 0);
            if (AnimDelay) yield return new WaitForSeconds(TempSet[1]);
        }
        MovTarget.transform.position += new Vector3(0, TempSet[2], 0);
        if (AnimDelay) yield return new WaitForSeconds(0.01f);
        MovTarget.transform.position -= new Vector3(0, TempSet[2], 0);
        if (AnimDelay) yield return new WaitForSeconds(1f);
        if (initMove)
        {
            for (int i = 0; i < 40; i++)
            {
                MovTarget.transform.position += new Vector3(0, 12, 0);
                if (AnimDelay) yield return new WaitForSeconds(0.02f);
            }
            Color DarkGrey = new Color(0.25f, 0.25f, 0.25f, 1);
            StartCoroutine(_changeColor(BackGround, Color.white, DarkGrey, 0.01f, false));
            for (int i = 0; i < 40; i++)
            {
                MovTarget.GetComponent<RectTransform>().sizeDelta += new Vector2(15, 15);
                if (AnimDelay) yield return new WaitForSeconds(0.02f);
            }
        }
        initMove = false;


        yield return null;
    }
    void _changePic(GameObject target, Sprite newPic)
    {
        target.GetComponent<Image>().sprite = newPic;
    }
    void _setInit(GameObject target, int index)
    {
        target.transform.localPosition = _initPos[index];
        target.GetComponent<RectTransform>().sizeDelta = _initSize[index];
    }
    void _setColor(GameObject target, Color orgColor, Color tarColor)
    {
        Color tempColor = new Color();
        tempColor = tarColor;
        target.GetComponent<Image>().color = Color.Lerp(orgColor, tempColor, 1);
    }
    IEnumerator _changeColor(GameObject target, Color orgColor, Color tarColor, float delay, bool Hide)
    {
        for (int i = 0; i < 100; i++)
        {
            float temp = (float)i / 100;
            if (i == 99) temp = 1;
            target.GetComponent<Image>().color = Color.Lerp(orgColor, tarColor, temp);
            yield return new WaitForSeconds(delay);
            if (!AnimDelay) { target.GetComponent<Image>().color = Color.Lerp(orgColor, tarColor, 1); break; }
        }
        
        if (Hide) { target.SetActive(false); }
        yield return null;
    }
    IEnumerator _changeSize(GameObject target, float times)
    {
        var temp = target.GetComponent<RectTransform>().sizeDelta;
        float tempCount;
        for (int i = 0; i < 10; i++)
        {
            tempCount = (float)i / 9;
            if (i == 9) tempCount = 9;

            target.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(temp, temp * times, tempCount);
            yield return new WaitForSeconds(0.01f);
            if (!AnimDelay) { target.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(temp, temp * times, 1); break; }
        }
        yield return null;
    }
    IEnumerator _flashScreen(GameObject target, Color tarColor)
    {
        float tempCount;
        target.SetActive(true);
        for (int i = 0; i < 5; i++)
        {
            tempCount = (float)i / 4;
            if (i == 9) tempCount = 4;
            target.GetComponent<Image>().color = Color.Lerp(Color.clear, tarColor, tempCount);
            yield return new WaitForSeconds(0.01f);
            if (!AnimDelay) { target.GetComponent<Image>().color = Color.Lerp(Color.clear, tarColor, 1); break; }
        }
        for (int i = 0; i < 10; i++)
        {
            tempCount = (float)i / 9;
            if (i == 9) tempCount = 9;
            target.GetComponent<Image>().color = Color.Lerp(tarColor, Color.clear, tempCount);
            yield return new WaitForSeconds(0.01f);
            if (!AnimDelay) { target.GetComponent<Image>().color = Color.Lerp(tarColor, Color.clear, 1); break; }
        }
        target.SetActive(false);
        yield return null;
    }
    IEnumerator _repos(GameObject target, Vector3 newpos)
    {
        Vector3 tempPos = target.transform.localPosition;
        for (int i = 0; i < 10; i++)
        {
            float tempCount = (float)i / 9;
            if (i == 9) tempCount = 9;
            target.transform.localPosition = Vector3.Lerp(tempPos, newpos, tempCount);
            yield return new WaitForSeconds(0.01f);
            if (!AnimDelay) { target.transform.localPosition = Vector3.Lerp(tempPos, newpos, 1); break; }
        }
        yield return null;
    }
    IEnumerator _rewind(float preset)
    {
        Showing = true;
        StartCoroutine(_changeColor(BackGround, Color.white, Color.black, 0.03f, false));
        if (AnimDelay) yield return new WaitForSeconds(4f);
        BackGround.GetComponent<Image>().material.SetFloat("_EffectAmount", preset);
        StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0.01f, false));
        if (AnimDelay) yield return new WaitForSeconds(1f);
        if (preset < 0.5f)
        {
            _setColor(Gryphon, Color.grey, Color.white);
            Gryphon.SetActive(true);
        }
        Showing = false;
        yield return null;
    }
    IEnumerator _showSuchiru()
    {
        StartCoroutine(_changeColor(Suchiru, Color.clear, Color.white, 0.02f, false));
        if (AnimDelay) yield return new WaitForSeconds(3f);
        StartCoroutine(_changeColor(BackGround, Color.clear, Color.white, 0.0f, false));
        StartCoroutine(_repos(Suchiru, new Vector3(420, 150, 0)));
        if (AnimDelay) yield return new WaitForSeconds(1f);
        BackGround.GetComponent<Image>().sprite = Suchiru.GetComponent<Image>().sprite;
        StartCoroutine(_changeColor(Suchiru, Color.white, Color.clear, 0.02f, false));
        if (AnimDelay) yield return new WaitForSeconds(3f);
        yield return null;
        Showing = false;
    }
    IEnumerator _soundProcedure(int index, System.Action task)
    {
        Showing = true;
        while (SoundMnger.SoundInstance.GetSe().isPlaying)
        {
            yield return new WaitForSeconds(0.01f);
            if (!AnimDelay) { SoundMnger.SoundInstance.StopSe(); break; }
        }
        SoundMnger.SoundInstance.GetSePlay(index);
        while (SoundMnger.SoundInstance.GetSe().isPlaying)
        {
            yield return new WaitForSeconds(0.01f);
            if (!AnimDelay) { SoundMnger.SoundInstance.StopSe(); break; }
        }
        task();
        Showing = false;
    }
    IEnumerator _enshitsuK(int index)
    {
        StartCoroutine(_changeColor(MiddleBar, Color.clear, Color.white, 0.01f, false));
        if (AnimDelay) yield return new WaitForSeconds(1f);
        ScreenMask.SetActive(true);
        _setColor(ScreenMask, Color.clear, Color.white);
        if (AnimDelay) yield return new WaitForSeconds(0.01f);
        _setColor(MiddleBar, Color.white, Color.clear);
        MiddleBar.SetActive(false);
        _changePic(Gryphon, GryphonPic.MobPics.GryphonSprite[index]);
        Gryphon.SetActive(true);
        StartCoroutine(_changeColor(ScreenMask, Color.white, Color.clear, 0.01f, false));
        yield return null;
    }
    IEnumerator _turnDark(System.Action task)
    {
        Showing = true;
        do
        {
            yield return new WaitForSeconds(0.01f);
        } while (ScenarioManager.SceneMngIns.getPrinting());
        ScreenMask.SetActive(true);
        StartCoroutine(_changeColor(ScreenMask, Color.clear, Color.black, 0.03f, false));
        if (AnimDelay) yield return new WaitForSeconds(3.0f);
        task();
        Showing = false;
        yield return null;
    }
    IEnumerator _enshitsuI(GameObject ZoomedBack, Vector3 newpos, Vector3 newscale)
    {
        Showing = true;
        Gryphon.SetActive(false);
        ZoomedBack.GetComponent<Image>().sprite = BackGround.GetComponent<Image>().sprite;
        StartCoroutine(_changeColor(Gryphon, Color.white, Color.clear, 0.01f, false));
        ZoomedBack.transform.localPosition = newpos;
        ZoomedBack.transform.localScale = newscale;
        if (AnimDelay) yield return new WaitForSeconds(1.5f);
        Gryphon.GetComponent<RectTransform>().sizeDelta = new Vector2(1080, 1920);
        Gryphon.transform.localScale = new Vector3(3, 3, 1);
        StartCoroutine(_repos(Gryphon, new Vector3(0, -1400, 0)));
        if (AnimDelay) yield return new WaitForSeconds(0.01f);
        StartCoroutine(_changeColor(Gryphon, Color.clear, Color.white, 0.02f, false));
        StartCoroutine(_changeColor(BackGround, Color.white, Color.clear, 0.02f, false));
        if (AnimDelay) yield return new WaitForSeconds(2.0f);
        Gryphon.SetActive(true);
        Showing = false;
        yield return null;
    }
    IEnumerator _doubleTeam()
    {
        Gryphon.transform.position += new Vector3(400, 0, 0);
        yield return new WaitForSeconds(0.5f);
        Gryphon.transform.position += new Vector3(-800, 0, 0);
        yield return new WaitForSeconds(0.5f);
        Gryphon.transform.position += new Vector3(400, 0, 0);
        yield return null;
    }
    IEnumerator delayRun(float delayTime, System.Action task)
    {
        if (AnimDelay) yield return new WaitForSeconds(delayTime);
        task();
    }
    IEnumerator EnshitsuE()
    {
        MiddleBar.SetActive(true);
        _changePic(MiddleBar, ShowManager.ItsShow.Kpic[3]);
        StartCoroutine(_changeSize(MiddleBar,1.0f/0.7f));
        ScreenMask.SetActive(true);
        _changePic(ScreenMask, ShowManager.ItsShow.Kpic[3]);
        _setColor(ScreenMask, Color.clear, Color.white);
        StartCoroutine(delayRun(2.0f,()=> { ScreenMask.SetActive(false);_changePic(ScreenMask, null);_setColor(ScreenMask,Color.white,Color.clear); StartCoroutine(_changeSize(MiddleBar, 0.7f)); }));
        yield return null;
    }
    #endregion
}
