using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragonShow : MonoBehaviour {
    public static DragonShow showDragon;
    public GameObject Dragon;
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
    public bool Showing = true;
    public bool AnimDelay = true;

    private bool vocalOnly = false;
    private Vector3[] _initPos = new Vector3[3];
    private Vector2[] _initSize = new Vector2[3];
    private int _showIndex = -1;
    private int vocalOnlyIndex = 0;
    
    void Awake()
    {
        showDragon = this;
    }

    void Start()
    {
        var tempEnshitsu = GameObject.FindGameObjectWithTag("Enshitsu").transform;
        preBack = tempEnshitsu.GetChild(0).gameObject;
        Box = tempEnshitsu.GetChild(3).gameObject;
        Dragon = tempEnshitsu.GetChild(4).gameObject;
        Letter = tempEnshitsu.GetChild(5).gameObject;
        BackGround = tempEnshitsu.GetChild(1).gameObject;
        Mao = tempEnshitsu.GetChild(6).gameObject;
        Food = tempEnshitsu.GetChild(7).gameObject;
        MiddleBar = tempEnshitsu.GetChild(8).gameObject;
        Suchiru = tempEnshitsu.GetChild(9).gameObject;
        _initPos[0] = Box.transform.localPosition;
        _initSize[0] = Box.GetComponent<RectTransform>().sizeDelta;
        _initPos[1] = Dragon.transform.localPosition;
        _initSize[1] = Dragon.GetComponent<RectTransform>().sizeDelta;
        _initPos[2] = Food.transform.localPosition;
        _initSize[2] = Food.GetComponent<RectTransform>().sizeDelta;
        BackGround.GetComponent<Image>().material.SetFloat("_EffectAmount", 0);
    }
    public void CallShow()
    {
        if (vocalOnly)
        {
            switch (vocalOnlyIndex)
            {
                case 0:
                    //18 -1
                    SoundMnger.SoundInstance.GetVocalPlay(0);
                    vocalOnly = false;
                    break;
                case 1:
                    //29 +2
                    SoundMnger.SoundInstance.GetVocalPlay(1);
                    vocalOnly = false;
                    break;
                case 2:
                    //43 -1
                    SoundMnger.SoundInstance.GetVocalPlay(4);
                    vocalOnly = false;
                    break;
                case 3:
                    //46 -1
                    SoundMnger.SoundInstance.GetVocalPlay(7);
                    vocalOnly = false;
                    break;
                case 4:
                    //52 +2
                    SoundMnger.SoundInstance.GetVocalPlay(7);
                    vocalOnly = false;
                    break;
                case 5:
                    //56 +2
                    SoundMnger.SoundInstance.GetVocalPlay(6);
                    vocalOnly = false;
                    break;
                case 6:
                    //61 -2
                    SoundMnger.SoundInstance.GetVocalPlay(6);
                    vocalOnly = false;
                    break;
                case 7:
                    //65 -1
                    SoundMnger.SoundInstance.GetVocalPlay(10);
                    vocalOnly = false;
                    break;
                case 8:
                    //66 -2
                    SoundMnger.SoundInstance.GetVocalPlay(8);
                    vocalOnly = false;
                    break;
                case 9:
                    //68 -2
                    SoundMnger.SoundInstance.GetVocalPlay(6);
                    break;
                case 10:
                    //68 -1
                    SoundMnger.SoundInstance.GetVocalPlay(8);
                    vocalOnly = false;
                    break;
                case 11:
                    //72 -2
                    SoundMnger.SoundInstance.GetVocalPlay(5);
                    vocalOnly = false;
                    break;
                case 12:
                    //75 +1
                    SoundMnger.SoundInstance.GetVocalPlay(8);
                    vocalOnly = false;
                    break;
                case 13:
                    //77 +3
                    SoundMnger.SoundInstance.GetVocalPlay(13);
                    vocalOnly = false;
                    break;
                case 14:
                    //88 +1
                    SoundMnger.SoundInstance.GetVocalPlay(12);
                    vocalOnly = false;
                    break;
                case 15:
                    //88+7
                    SoundMnger.SoundInstance.GetVocalPlay(13);
                    vocalOnly = false;
                    break;
                case 16:
                    //88 +9
                    SoundMnger.SoundInstance.GetVocalPlay(14);
                    break;
                case 17:
                    //88 +10
                    SoundMnger.SoundInstance.GetVocalPlay(15);
                    vocalOnly = false;
                    break;
                case 18:
                    //88 +15
                    SoundMnger.SoundInstance.GetVocalPlay(16);
                    break;
                case 19:
                    //88 +16
                    SoundMnger.SoundInstance.GetVocalPlay(17);
                    break;
                case 20:
                    //88 +17
                    SoundMnger.SoundInstance.GetVocalPlay(18);
                    vocalOnly = false;
                    break;
                
            }
            vocalOnlyIndex++;
        }
        else
        {
            switch (_showIndex)
            {
                case -1:
                    _changePic(ScreenMask, null);
                    StartCoroutine(_changeColor(ScreenMask, Color.black, Color.clear, 0.03f, true));
                    SoundMnger.SoundInstance.GetSePlay(0);
                    SoundMnger.SoundInstance.GetBgmPlay(0);
                    StartCoroutine(delayRun(3.0f, () => { ScenarioManager.SceneMngIns.StartPrint = true; ScenarioManager.SceneMngIns.Once = true; }));
                    break;
                case 0:
                    Box.SetActive(true);
                    StartCoroutine(PopOut(Box, true));

                    break;
                case 1:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    _changePic(Box, ShowManager.ItsShow.BoxPic[1]);
                    _setInit(Box, 0);
                    StartCoroutine(PopOut(Box, false));
                    SoundMnger.SoundInstance.GetScaling(false);
                    SoundMnger.SoundInstance.GetSePlay(1);
                    StartCoroutine(delayRun(1.0f,()=>{ ScenarioManager.SceneMngIns.StartPrint = true;ScenarioManager.SceneMngIns.Once = true; }));
                    break;
                case 2:
                    Dragon.SetActive(true);
                    SoundMnger.SoundInstance.GetVocalPlay(2);
                    _setColor(Dragon, Color.white, Color.grey);
                    StartCoroutine(_changeColor(BackGround, new Color(0.25f, 0.25f, 0.25f, 1), Color.white, 0.01f, false));
                    StartCoroutine(_changeColor(Box, Color.white, Color.clear, 0.01f, false));

                    break;
                case 3:
                    Letter.SetActive(true);
                    Dragon.SetActive(false);
                    StartCoroutine(PopOut(Letter, false));

                    break;
                case 4:
                    Letter.SetActive(false);
                    StartCoroutine(_changeColor(BackGround, Color.white, Color.black, 0.01f, false));

                    break;
                case 5:
                    Mao.SetActive(true);
                    _changePic(Mao, ShowManager.ItsShow.MaoPic[2]);
                    SoundMnger.SoundInstance.GetBgmPlay(1);
                    SoundMnger.SoundInstance.GetScaling(true);
                    break;
                case 6:
                    _changePic(Mao, ShowManager.ItsShow.MaoPic[1]);

                    break;
                case 7:
                    _changePic(Mao, ShowManager.ItsShow.MaoPic[2]);
                    break;
                case 8:
                    Mao.SetActive(false);
                    break;
                case 9:
                    SoundMnger.SoundInstance.GetScaling(false);
                    StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0.01f, false));
                    break;
                case 10:
                    SoundMnger.SoundInstance.GetSePlay(2);
                    StartCoroutine(_changeColor(BackGround, Color.white, Color.black, 0.01f, false));
                    break;
                case 11:
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[0]);
                    StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0.01f, false));
                    Dragon.SetActive(true);
                    break;
                case 12:
                    _setColor(Dragon, Color.grey, Color.white);
                    break;
                case 13:
                    SoundMnger.SoundInstance.GetVocalPlay(2);
                    _setColor(Dragon, Color.white, Color.grey);
                    Food.SetActive(true);
                    StartCoroutine(PopOut(Food, false));
                    break;
                case 14:
                    _setInit(Food, 2);
                    Food.SetActive(false);
                    break;
                case 15:
                    SoundMnger.SoundInstance.GetVocalPlay(0);
                    StartCoroutine(_changeSize(Dragon, (1f / 0.7f)));
                    Dragon.GetComponent<Image>().sprite = DragonPic.MobPics.DragonSprite[2];
                    _setColor(Dragon, Color.grey, Color.white);
                    break;
                case 16:
                    SoundMnger.SoundInstance.GetSePlay(3);
                    ScreenMask.SetActive(true);
                    StartCoroutine(_flashScreen(ScreenMask, Color.blue));
                    break;
                case 17:
                    StartCoroutine(_repos(Dragon, new Vector3(0, -150, 0)));
                    StartCoroutine(_changeSize(Dragon, (1f / 0.7f)));
                    vocalOnly = true;
                    break;
                case 18:
                    SoundMnger.SoundInstance.GetSePlay(4);
                    StartCoroutine(_changeSize(Dragon, 0.49f));
                    StartCoroutine(_repos(Dragon, new Vector3(0, 0, 0)));
                    break;
                case 19:
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[1]);
                    break;
                case 20:
                    Food.SetActive(true);
                    SoundMnger.SoundInstance.GetVocalPlay(3);
                    SoundMnger.SoundInstance.GetSePlay(5);
                    StartCoroutine(PopOut(Food, false));
                    break;
                case 21:
                    _setInit(Food, 2);
                    Food.SetActive(false);
                    _setColor(Dragon, Color.white, Color.grey);
                    break;
                case 22:
                    _setColor(Dragon, Color.grey, Color.white);
                    break;
                case 23:
                    StartCoroutine(_changeSize(Dragon, (1f / 0.7f)));
                    break;
                case 24:
                    _setColor(Dragon, Color.white, Color.grey);
                    StartCoroutine(_changeSize(Dragon, 0.7f));
                    break;
                case 25:
                    Dragon.SetActive(false);
                    break;
                case 26:
                    SoundMnger.SoundInstance.GetScaling(true);
                    SoundMnger.SoundInstance.GetBgmPlay(5);
                    Dragon.SetActive(true);
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[1]);
                    break;
                case 27:
                    SoundMnger.SoundInstance.GetVocalPlay(1);
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[0]);
                    _setColor(Dragon, Color.grey, Color.white);
                    break;
                case 28:
                    SoundMnger.SoundInstance.GetSePlay(1);
                    StartCoroutine(_changeSize(Dragon, (1f / 0.7f)));
                    break;
                case 29:
                    StartCoroutine(_enshitsuI(preBack, new Vector3(0, 0, 0), new Vector3(1.6f, 1.6f, 1.6f)));
                    vocalOnly = true;
                    break;
                case 30:
                    _setInit(Dragon, 1);
                    Dragon.SetActive(false);
                    SoundMnger.SoundInstance.GetScaling(false);
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    StartCoroutine(_turnDark(() => { ScenarioManager.SceneMngIns.StartPrint = true; ScenarioManager.SceneMngIns.Once = true; }));
                    break;
                case 31:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    _setColor(BackGround, Color.white, Color.black);
                    StartCoroutine(_changeColor(ScreenMask, Color.black, Color.clear, 0.03f, true));
                    StartCoroutine(delayRun(3.0f, () => { ScenarioManager.SceneMngIns.StartPrint = true; }));
                    break;
                case 32:
                    _changePic(BackGround, BackGroundPic.AccsBack.BackGroundSprite[1]);
                    StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0.01f, false));
                    SoundMnger.SoundInstance.GetSePlay(6);
                    break;
                case 33:
                    SoundMnger.SoundInstance.GetSePlay(0);
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[1]);
                    StartCoroutine(_soundProcedure(7, () => { Dragon.SetActive(true); }));
                    SoundMnger.SoundInstance.GetBgmPlay(3);
                    break;
                case 34:
                    _setColor(Dragon, Color.white, Color.grey);
                    break;
                case 35:
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[0]);
                    _setColor(Dragon, Color.grey, Color.white);
                    break;
                case 36:
                    SoundMnger.SoundInstance.GetSePlay(15);
                    Dragon.SetActive(false);
                    break;
                case 37:
                    Dragon.SetActive(true);
                    SoundMnger.SoundInstance.GetVocalPlay(1);
                    _setColor(Dragon, Color.grey, Color.white);
                    StartCoroutine(_changeSize(Dragon, (1f / 0.7f)));
                    break;
                case 38:
                    SoundMnger.SoundInstance.GetSePlay(8);
                    break;
                case 39:
                    SoundMnger.SoundInstance.GetSePlay(9);
                    Dragon.SetActive(false);
                    break;
                case 40:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    SoundMnger.SoundInstance.GetScaling(false);
                    StartCoroutine(_turnDark(() => { ScenarioManager.SceneMngIns.StartPrint = true; }));
                    break;
                case 41:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    _changePic(BackGround, BackGroundPic.AccsBack.BackGroundSprite[2]);
                    StartCoroutine(_changeColor(ScreenMask, Color.black, Color.clear, 0.04f, true));
                    StartCoroutine(delayRun(3.0f, () => { ScenarioManager.SceneMngIns.StartPrint = true; }));
                    break;
                case 42:
                    SoundMnger.SoundInstance.GetSePlay(0);
                    SoundMnger.SoundInstance.GetScaling(true);
                    SoundMnger.SoundInstance.GetBgmPlay(0);
                    vocalOnly = true;
                    break;
                case 43:
                    SoundMnger.SoundInstance.GetSePlay(4);
                    StartCoroutine(_soundProcedure(10, () => { }));
                    
                    break;
                case 44:
                    StartCoroutine(_changeColor(BackGround, Color.white, Color.black, 0f, false));
                    break;
                case 45:
                    StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0f, false));
                    Dragon.SetActive(true);
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[3]);
                    vocalOnly = true;
                    break;
                case 46:
                    _setColor(Dragon, Color.white, Color.grey);
                    Dragon.SetActive(false);
                    StartCoroutine(_rewind(1));
                    break;
                case 47:
                    StartCoroutine(_soundProcedure(11, () => { }));
                    SoundMnger.SoundInstance.GetSePlay(11);
                    break;
                case 48:
                    StartCoroutine(_rewind(0));
                    break;
                case 49:
                    Dragon.SetActive(true);
                    break;
                case 50:
                    _setColor(Dragon, Color.white, Color.grey);
                    break;
                case 51:
                    StartCoroutine(_changeSize(Dragon, (1f / 0.7f)));
                    break;
                case 52:
                    SoundMnger.SoundInstance.GetVocalPlay(7);
                    _setColor(Dragon, Color.grey, Color.white);
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[4]);
                    StartCoroutine(_changeSize(Dragon, 0.7f));
                    vocalOnly = true;
                    break;
                case 53:
                    _setColor(Dragon, Color.white, Color.grey);
                    break;
                case 54:
                    _setColor(Dragon, Color.grey, Color.white);
                    break;
                case 55:
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[3]);
                    SoundMnger.SoundInstance.GetVocalPlay(6);
                    break;
                case 56:
                    StartCoroutine(_changeSize(Dragon, (1f / 0.7f)));
                    vocalOnly = true;
                    break;
                case 57:
                    Dragon.SetActive(false);
                    SoundMnger.SoundInstance.GetScaling(false);
                    _setInit(Dragon, 1);
                    StartCoroutine(_changeColor(BackGround, Color.white, Color.black, 0.01f, false));
                    break;
                case 58:
                    SoundMnger.SoundInstance.GetBgmPlay(2);
                    SoundMnger.SoundInstance.GetScaling(true);
                    break;
                case 59:
                    StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0.01f, false));
                    _changePic(BackGround, BackGroundPic.AccsBack.BackGroundSprite[5]);
                    SoundMnger.SoundInstance.GetSePlay(0);
                    break;
                case 60:
                    SoundMnger.SoundInstance.GetSePlay(0);
                    vocalOnly = true;
                    break;
                case 61:
                    _initSize[1]= new Vector2(1080, 1920);
                    _setInit(Dragon, 1);
                    SoundMnger.SoundInstance.GetSePlay(4);
                    _changePic(MiddleBar, ShowManager.ItsShow.Kpic[0]);
                    StartCoroutine(_enshitsuK(5));
                    break;
                case 62:
                    SoundMnger.SoundInstance.GetSePlay(12);
                    break;
                case 63:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    SoundMnger.SoundInstance.GetScaling(false);
                    Dragon.SetActive(false);
                    StartCoroutine(_turnDark(() => { ScenarioManager.SceneMngIns.StartPrint = true; ScenarioManager.SceneMngIns.Once = true; }));
                    break;
                case 64:
                    _changePic(BackGround, BackGroundPic.AccsBack.BackGroundSprite[5]);
                    StartCoroutine(_changeColor(ScreenMask, Color.black, Color.clear, 0.04f, true));
                    StartCoroutine(delayRun(4.0f, () => { }));
                    SoundMnger.SoundInstance.GetBgmPlay(2);
                    SoundMnger.SoundInstance.GetScaling(true);
                    Dragon.SetActive(true);
                    vocalOnly = true;
                    break;
                case 65:
                    SoundMnger.SoundInstance.GetSePlay(12);
                    ScreenMask.SetActive(true);
                    StartCoroutine(_flashScreen(ScreenMask, Color.blue));
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[6]);
                    vocalOnly = true;
                    break;
                case 66:
                    _setColor(Dragon, Color.white, Color.grey);
                    break;
                case 67:
                    SoundMnger.SoundInstance.GetVocalPlay(11);
                    _setColor(Dragon, Color.grey, Color.white);
                    vocalOnly = true;
                    break;
                case 68:
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[5]);
                    break;
                case 69:
                    _setColor(Dragon, Color.white, Color.grey);
                    break;
                case 70:
                    SoundMnger.SoundInstance.GetScaling(false);
                    break;
                case 71:
                    SoundMnger.SoundInstance.GetScaling(true);
                    SoundMnger.SoundInstance.GetBgmPlay(5);
                    _setColor(Dragon, Color.grey, Color.white);
                    vocalOnly = true;
                    break;
                case 72:
                    SoundMnger.SoundInstance.GetVocalPlay(9);
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[3]);
                    break;
                case 73:
                    SoundMnger.SoundInstance.GetSePlay(4);
                    break;
                case 74:
                    SoundMnger.SoundInstance.GetVocalPlay(6);
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[4]);
                    break;
                case 75:
                    SoundMnger.SoundInstance.GetSePlay(4);
                    StartCoroutine(_soundProcedure(13, () => { })); //need stop early
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[3]);
                    StartCoroutine(_changeSize(Dragon, (1f / 0.7f)));
                    vocalOnly = true;
                    break;
                case 76:
                    //意味わかんないの表示
                    SoundMnger.SoundInstance.GetSePlay(8);
                    break;
                case 77:
                    Showing = true;
                    _changePic(whiteScreen, null);
                    StartCoroutine(_changeColor(whiteScreen, Color.clear, Color.white, 0.01f, false));
                    Dragon.SetActive(false);
                    SoundMnger.SoundInstance.GetScaling(false);
                    SoundMnger.SoundInstance.GetSePlay(9);
                    vocalOnly = true;
                    break;
                case 78:
                    Showing = true;
                    SoundMnger.SoundInstance.GetScaling(true);
                    SoundMnger.SoundInstance.GetBgmPlay(4);
                    StartCoroutine(_changeColor(whiteScreen, Color.white, Color.clear, 0.01f, true));
                    MiddleBar.SetActive(true);
                    _changePic(MiddleBar, ShowManager.ItsShow.Kpic[1]);
                    StartCoroutine(_repos(Dragon, new Vector3(0, -100)));
                    StartCoroutine(_changeSize(Dragon, 0.8f));
                    StartCoroutine(_enshitsuK(8));
                    break;
                case 79:
                    SoundMnger.SoundInstance.GetVocalPlay(7);
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[11]);
                    break;
                case 80:
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[9]);
                    break;
                case 81:
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[7]);
                    break;
                case 82:
                    SoundMnger.SoundInstance.GetVocalPlay(5);
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[10]);
                    break;
                case 83:
                    SoundMnger.SoundInstance.GetSePlay(8);
                    StartCoroutine(_repos(Dragon, new Vector3(0, -400)));
                    StartCoroutine(_changeSize(Dragon, 1.5f));
                    break;
                case 84:
                    ScenarioManager.SceneMngIns.StartPrint = false;
                    SoundMnger.SoundInstance.GetScaling(false);
                    StartCoroutine(_turnDark(() => { ScenarioManager.SceneMngIns.StartPrint = true; ScenarioManager.SceneMngIns.Once = true; }));
                    break;
                case 85:
                    _changePic(BackGround, BackGroundPic.AccsBack.BackGroundSprite[1]);
                    StartCoroutine(_changeColor(ScreenMask, Color.black, Color.clear, 0.01f, true));
                    break;
                case 86:
                    SoundMnger.SoundInstance.GetVocalPlay(11);
                    _changePic(Dragon, DragonPic.MobPics.DragonSprite[7]);
                    break;
                case 87:
                    Dragon.SetActive(false);
                    break;
                case 88:
                    Showing = true;
                    SoundMnger.SoundInstance.GetSePlay(14);
                    SoundMnger.SoundInstance.GetBgmPlay(3);
                    SoundMnger.SoundInstance.GetScaling(true);
                    StartCoroutine(_showSuchiru());
                    vocalOnly = true;
                    break;
                case 89:
                    ScenarioManager.SceneMngIns.SetPause(true);
                    SoundMnger.SoundInstance.GetScaling(false);
                    _changePic(ScreenMask,ShowManager.ItsShow.EndScene);
                    StartCoroutine(_turnDark(() => { StartCoroutine(delayRun(3f, () => { SceneManager.LoadScene("title"); SoundMnger.SoundInstance.ReloadSound(); })); }));
                    break;

            }
            _showIndex++;
        }
        Debug.Log(_showIndex);
    }
	
	void Update () {
		
	}
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
    void _changePic(GameObject target,Sprite newPic)
    {
        target.GetComponent<Image>().sprite = newPic;
    }
    void _setInit(GameObject target, int index)
    {
        target.transform.localPosition = _initPos[index];
        target.GetComponent<RectTransform>().sizeDelta = _initSize[index];
    }
    void _setColor(GameObject target,Color orgColor, Color tarColor)
    {
        Color tempColor = new Color();
        tempColor = tarColor;
        target.GetComponent<Image>().color = Color.Lerp(orgColor,tempColor,1);
    }
    IEnumerator _changeColor(GameObject target,Color orgColor,Color tarColor,float delay,bool Hide)
    {
            for (int i = 0; i < 100; i++)
            {
                float temp = (float)i / 100;
                if (i == 99) temp = 1;
               target.GetComponent<Image>().color =  Color.Lerp(orgColor, tarColor, temp);
                yield return new WaitForSeconds(delay);
            if (!AnimDelay) { target.GetComponent<Image>().color = Color.Lerp(orgColor, tarColor,1);break; }
            }

        if (Hide) { target.SetActive(false); }
        yield return null;
    }
    IEnumerator _changeSize(GameObject target,float times)
    {
        var temp = target.GetComponent<RectTransform>().sizeDelta;
        float tempCount;
        for (int i= 0; i < 10; i++)
        {
            tempCount = (float)i / 9;
            if (i == 9) tempCount = 9;
            
            target.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(temp, temp * times,tempCount);
            yield return new WaitForSeconds(0.01f);
            if (!AnimDelay) { target.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(temp, temp * times, 1);break; }
        }
        yield return null;
    }
    IEnumerator _flashScreen(GameObject target,Color tarColor)
    {
        float tempCount;
        target.SetActive(true);
        for(int i = 0; i < 5; i++)
        {
            tempCount = (float)i / 4;
            if (i == 9) tempCount = 4;
            target.GetComponent<Image>().color = Color.Lerp(Color.clear, tarColor, tempCount);
            yield return new WaitForSeconds(0.01f);
            if (!AnimDelay) { target.GetComponent<Image>().color = Color.Lerp(Color.clear, tarColor, 1);break; }
        }
        for (int i = 0; i < 10; i++)
        {
            tempCount = (float)i / 9;
            if (i == 9) tempCount = 9;
            target.GetComponent<Image>().color = Color.Lerp(tarColor,Color.clear, tempCount);
            yield return new WaitForSeconds(0.01f);
            if (!AnimDelay) { target.GetComponent<Image>().color = Color.Lerp(tarColor, Color.clear, 1);break; }
        }
        target.SetActive(false);
        yield return null;
    }
    IEnumerator _repos(GameObject target, Vector3 newpos)
    {
        Vector3 tempPos = target.transform.localPosition;
        for(int i = 0; i < 10; i++)
        {
            float tempCount = (float)i/9;
            if (i == 9) tempCount = 9;
            target.transform.localPosition = Vector3.Lerp(tempPos, newpos, tempCount);
            yield return new WaitForSeconds(0.01f);
            if (!AnimDelay) { target.transform.localPosition = Vector3.Lerp(tempPos, newpos, 1);break; }
        }
        yield return null;
    }
    IEnumerator _rewind(float preset)
    {
        
        StartCoroutine(_changeColor(BackGround, Color.white, Color.black, 0.03f, false));
        if(AnimDelay)yield return new WaitForSeconds(4f);
        BackGround.GetComponent<Image>().material.SetFloat("_EffectAmount", preset);
        StartCoroutine(_changeColor(BackGround, Color.black, Color.white, 0.01f, false));
        if (AnimDelay) yield return new WaitForSeconds(1f);
        if(preset < 0.5f)
        {
            _setColor(Dragon, Color.grey, Color.white);
            Dragon.SetActive(true);
        }
        
        yield return null;
    }
    IEnumerator _showSuchiru()
    {
        StartCoroutine(_changeColor(Suchiru, Color.clear,Color.white, 0.02f,false));
        if (AnimDelay) yield return new WaitForSeconds(3f);
        StartCoroutine(_repos(Suchiru, new Vector3(420 , 150, 0)));
        if (AnimDelay) yield return new WaitForSeconds(1f);
        BackGround.GetComponent<Image>().sprite = Suchiru.GetComponent<Image>().sprite;
        StartCoroutine(_changeColor(Suchiru, Color.white, Color.clear, 0.02f, false));
        if (AnimDelay) yield return new WaitForSeconds(3f);
        yield return null;
        
    }
    IEnumerator _soundProcedure(int index, System.Action task)
    {
        
        while (SoundMnger.SoundInstance.GetSe().isPlaying)
        {
            yield return new WaitForSeconds(0.01f);
            if (!AnimDelay) { SoundMnger.SoundInstance.StopSe();break; }
        }
        SoundMnger.SoundInstance.GetSePlay(index);
        while (SoundMnger.SoundInstance.GetSe().isPlaying)
        {
            yield return new WaitForSeconds(0.01f);
            if (!AnimDelay) { SoundMnger.SoundInstance.StopSe(); break; }
        }
        task();
        
    }
    IEnumerator _enshitsuK(int index)
    {
        StartCoroutine(_changeColor(MiddleBar, Color.clear, Color.white, 0.01f, false));
        if (AnimDelay) yield return new WaitForSeconds(2f);
        ScreenMask.SetActive(true);
        _setColor(ScreenMask, Color.clear, Color.white);
        if (AnimDelay) yield return new WaitForSeconds(0.01f);
        _setColor(MiddleBar, Color.white, Color.clear);
        MiddleBar.SetActive(false);
        StartCoroutine(_changeColor(MiddleBar, Color.white, Color.clear, 0.0f, false));
        _changePic(Dragon,DragonPic.MobPics.DragonSprite[index]);
        Dragon.SetActive(true);
        StartCoroutine(_changeColor(ScreenMask, Color.white, Color.clear, 0.01f, false));
        yield return null;
    }
    IEnumerator _turnDark(System.Action task)
    {
        do
        {
            yield return new WaitForSeconds(0.01f);
        } while (ScenarioManager.SceneMngIns.getPrinting());
        ScreenMask.SetActive(true);
        StartCoroutine(_changeColor(ScreenMask, Color.clear, Color.black, 0.03f, false));
        if (AnimDelay) yield return new WaitForSeconds(3.0f);
        task();
        yield return null;
    }
    IEnumerator _enshitsuI(GameObject ZoomedBack,Vector3 newpos,Vector3 newscale)
    {
        
        StartCoroutine(_changeColor(Dragon, Color.white, Color.clear, 0.01f, false));
        ZoomedBack.transform.localPosition = newpos;
        ZoomedBack.transform.localScale = newscale;
        if (AnimDelay) yield return new WaitForSeconds(1.5f);
        StartCoroutine(_repos(Dragon, new Vector3(0, -300, 0)));
        if (AnimDelay) yield return new WaitForSeconds(0.01f);
        StartCoroutine(_changeColor(Dragon, Color.clear, Color.white, 0.02f, false));
        StartCoroutine(_changeColor(BackGround, Color.white, Color.clear, 0.02f, false));
        if (AnimDelay) yield return new WaitForSeconds(2.0f);
        
        yield return null;
    }
    IEnumerator delayRun(float delayTime,System.Action task)
    {
        if (AnimDelay) yield return new WaitForSeconds(delayTime);
        task();
    }
}

