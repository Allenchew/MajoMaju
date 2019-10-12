using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//演出のフラグ
public class ScenarioManager : MonoBehaviour {
    //シナリオの種類
    public enum ScenarioType
    {
        SFides,
        SGryphon,
        SWolf
    }

    enum GameMode
    {
         Scenario,
         MiniGame
    }

    public static ScenarioManager SceneMngIns;
    public bool StartEnshitsu = false;
    public bool StartPrint = false;
    public float printdelay;
    public bool[] CharacterInGrey = new bool[] { false,false,false,false};
    public Sprite[] StartingPic = new Sprite[] { };
   // public bool StartMinigame = false;
    public bool Once = false;
   
    public Text DialogName;
    public Text DialogBox;
    public InputField NameField;
    public GameObject ConfirmButton;
    public GameObject ScenarioButton;
   // public GameObject[] miniGameObj = new GameObject[] { };
    public GameObject DialogObjs;
    public GameObject MainCharacter;
    public GameObject MainUi;
    public GameObject EnShitsu;
    public GameObject ScreenMask;

    [System.NonSerialized]
    public ScenarioType SType = ScenarioType.SFides;

    private GameMode CurrentMode = 0;
    private int repeatCounter = 0;
    private int NagareCounter = 0;
    private int TotalCount;
    private float ChatDelay = 1.0f;
    private float CountHold = 0;
    private EnshitsuFunc EnshitsuController = new EnshitsuFunc();
    private bool StartGame = false;
    private bool pauseGame = false;
    private bool fastforwardmode = false;
    private bool FFing = false;
    private bool AutoMode = false;
    private bool printing = false;
    private string tempName = "";
    private string[] Charactername = new string[] { };
    private string[] MonsterName = new string[] { };
    private string[][] CurrentCharacter = new string[4][] { new string[] { }, new string[] { }, new string[] { }, new string[] { } };
    private int[] transformStep = new int[] { };
    private int[] MiniGameEntry = new int[] { };
    private int CurrentStep = 0;
    private int CurrentGame = 0;
    private int[] SerifuCounter = new int[] { 0, 0, 0, 0 };
    private int[] Nagare = new int[] {};
    private int[] RepeatTimes = new int[] { } ;
    private int[] DragonShowNumber = new int[]
     {
         0,2,4,4,8,10,11,12,13,16,17,19,20,21,22,24,25,26,27,29,30,31,33,34,36,37,40,41,42,43,46,47,49,55,56,56,57,59,64,66,67,74,77,78,79,79,81,82,83,84,87,88,89,94,95,96,98,100,
         102,104,105,107,111,113,115,116,120,124,127,129,134,137,137,138,139,142,144,147,150,151,152,155,157,158,159,161,164,168,171,172,174,178,181,183,185,187,189,192,193,196,196,
         197,202,204,205,211,213,214,219,220,221,222

     };
    private int[] GryphonShowNumber = new int[]
    {
        0,2,3,7,7,13,15,16,16,17,18,19,22,23,27,30,33,34,38,39,39,40,41,42,43,44,45,47,50,52,59,60,63,65,68,69,70,71,72,73,77,82,83,87,92,93,97,98,100,101,103,105,106,113,114,114,116,118,
        119,122,123,124,125,127,129,131,134,135,139,140,141,142,143,145,149,152,155,157,158,159,163,165,166,167,169,171,173,174,176,177,179,180,183,186,187,190,194,196,197,198,199,201,202,205,206,207,208,210,213,215,220,221,225
    };
    private int showCount = 0;
    private void Awake()
    {
        Screen.SetResolution(2048, 1536, false);
        SceneMngIns = this;
    }
    //文字をプリントする機能
	void Update () {
        
        if (StartGame && !pauseGame)
        {
            //加速モードのフラグ
            if (fastforwardmode)
            {
                CountHold += Time.deltaTime;
                if (CountHold > 0.5f)
                {
                    FFing = true;
                    printdelay = 0;
                    ChatDelay = 0f;
                }
            }
            if (Once||(Input.GetMouseButtonDown(0) || FFing || AutoMode) && !printing)
                {
                DragonShow.showDragon.AnimDelay = true;
                GryphonShow.showGryphon.AnimDelay = true;
                if (Nagare[NagareCounter] == -1)
                    {
                        StartGame = false;
                        return;
                    }
                    else
                    {
                    TotalCount = SerifuCounter[0] + SerifuCounter[1] + SerifuCounter[2] + SerifuCounter[3];

                    if (TotalCount == (SType == ScenarioType.SFides ? DragonShowNumber[showCount] : GryphonShowNumber[showCount]))
                    {
                        switch (SType)
                        {
                            case ScenarioType.SFides:
                                DragonShow.showDragon.CallShow();
                                break;
                            case ScenarioType.SGryphon:
                                GryphonShow.showGryphon.CallShow();
                                break;
                        }
                        showCount++;
                    }
                    if (StartPrint)
                    {
                        if (repeatCounter == RepeatTimes[NagareCounter])
                        {
                            NagareCounter++;
                            repeatCounter = 0;
                        }
                        if (CurrentStep < 2 && SerifuCounter[2] == transformStep[CurrentStep])
                        {
                            if (CurrentStep < transformStep.Length)
                            {
                                CurrentStep++;
                                Charactername[2] = MonsterName[CurrentStep];
                            }
                            else
                                Charactername[2] = MonsterName[transformStep.Length - 1];
                        }
                        DialogName.text = Charactername[Nagare[NagareCounter]];
                        StartCoroutine(PrintOut(CurrentCharacter[Nagare[NagareCounter]][SerifuCounter[Nagare[NagareCounter]]]));
                        SerifuCounter[Nagare[NagareCounter]]++;
                        repeatCounter++;
                    }
                    Once = false;
                }
            }
            else if (Input.GetMouseButtonDown(0) && printing && !fastforwardmode)
            {
                GryphonShow.showGryphon.AnimDelay = false;
                DragonShow.showDragon.AnimDelay = false;
                AutoMode = false;
                ChatDelay = 0.05f;
                printdelay = 0f;
            }
            
        }else if (pauseGame && Input.GetMouseButtonDown(0))
        {
            if (MainUi.activeSelf == false)
            {
                MainUi.SetActive(true);
                pauseGame = false;
            }
        }
    }
    //名前を入力欄処理
    public void ConfirmName()
    {
        tempName = NameField.text;
        NameField.gameObject.SetActive(false);
        ConfirmButton.SetActive(false);
        ScreenMask.GetComponent<Image>().sprite = StartingPic[1];
        ScenarioButton.SetActive(true);
    }
    //加速モードの切り替え
    public void OnHoldFF(int index)
    {
        switch (index)
        {
            case 0:
                if (!AutoMode)
                {
                    AutoMode = true;
                    printdelay = 0.05f;
                    ChatDelay = 1.0f;
                }
                else
                {
                    AutoMode = false;
                    printdelay = 0.05f;
                    ChatDelay = 0f;
                }
                break;
            case 1:
                fastforwardmode = true;
                AutoMode = false;
                break;
            case 2:
                fastforwardmode = false;
                if (CountHold > 0.5f)
                {
                    FFing = false;
                    printdelay = 0.05f;
                    ChatDelay = 0f;
                }
                CountHold = 0;
                break;
        }
    }
    //UIの表示の切り替え
    public void TurnOffUi()
    {
        MainUi.SetActive(false);
        pauseGame = true;
        AutoMode = false;
        ChatDelay = 0f;
        printdelay = 0f;
    }
    //ゲームをポーズ
    public void SetPause(bool preset)
    {
        pauseGame = preset;
    }
    public bool getPrinting()
    {
        return printing;
    }
    
    public void ChooseScenario(int index)
    {
        switch (index)
        {
            case 0:
                SType = ScenarioType.SFides;
                break;
            case 1:
                SType = ScenarioType.SGryphon;
                break;
            case 2:
                SType = ScenarioType.SWolf;
                break;
            default:
                break;
        }
        ScenarioButton.SetActive(false);
        DialogObjs.SetActive(true);
        SoundMnger.SoundInstance.StartPlay = true;
        GameInit();
    }
    private void GameInit()
    {
        int tempIndex = (int)SType;
        Scenario.Username = tempName;
        Scenario GetScenario = new Scenario();
        MonsterName = GetScenario.GetMobsName(tempIndex);
        Charactername = GetScenario.GetCharName(tempIndex);
        Charactername[2] = MonsterName[CurrentStep];
        CurrentCharacter = GetScenario.GetAllScenario(tempIndex);
        Nagare = GetScenario.GetNagare(tempIndex);
        RepeatTimes = GetScenario.GetRepeat(tempIndex);
        transformStep = GetScenario.GetStep(tempIndex);
        //MiniGameEntry = GetScenario.GetEntry(tempIndex);
        Once = true;
        StartGame = true;
        MainUi.SetActive(true);
    }
    //文字をプリントする機能
    IEnumerator PrintOut(string scenarioTexts)
    {
        printing = true;
        if(!fastforwardmode)
            printdelay = 0.05f;
        DialogBox.text = "";
        foreach(char Letter in scenarioTexts)
        {
            DialogBox.text += Letter;
            yield return new WaitForSeconds(printdelay);
            if (printdelay == 0f)
            {
                DialogBox.text = scenarioTexts;
                break;
            }
        }
        yield return new WaitForSeconds(ChatDelay);
        printing = false;
    }
   
}
