using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMnger : MonoBehaviour {
    

    public static GameMnger Ins;

    public bool GameEnd = false;
    public bool Pausing = false;
    public float GenerateSpd = 0.5f;
    public float ScaleSpd = 0.01f;

    public GameObject MiniGameSceneObj;
    public GameObject GuidePage;
    public GameObject DropObjContainer;
    public GameObject[] DropObj = new GameObject[2];
    public GameObject EndGame;
   
    public int Time = 30; //20
    public Text StartCounter;
    public Text GameTimer;
    public Text GameScore;
    public int Scores = 0;

    private int CurrentStages = 0;
    private int[][] InitStates = new int[][] { new int[] { 30, 15, 10 }, new int[] { 20, 10, 6 }};
    private int SweetsNumber = 15; 
    private bool GameRunning = false;
	// Use this for initialization
	void Start () {
        Ins = this;
        StartCoroutine(ScaleScreen(GuidePage));
	}
	
	// Update is called once per frame
	void Update () {
        if (Time >=0) PrintTime();
        if (TutorialButton.TriggerStart)
        {
            TutorialButton.TriggerStart = false;
            StartCoroutine("TimeCounter");
        }
        if(!Pausing)
            GameScore.text = Scores.ToString() + " / "+InitStates[CurrentStages][2].ToString();
    }
    IEnumerator ScaleScreen(GameObject ScreenObj)
    {
        for(int i = 0; i < 30; i++)
        {
            ScreenObj.transform.localScale += new Vector3(0.03f, 0.03f);
            yield return new WaitForSeconds(ScaleSpd);
        }
    }
    IEnumerator TimeCounter()
    {
        for(int j = 0; j < 4; j++)
        {
            StartCounter.text = (3 - j).ToString();
            if (j == 3)
                StartCounter.text = "Start";
            yield return new WaitForSeconds(1.0f);
            StartCounter.text = "";
        }
        GameRunning = true;
        StartCoroutine("GenerateObj");
        
        for (Time = InitStates[CurrentStages][0];Time>=0; Time--){
            while (Pausing)
            {
                if (!Pausing) break;
                yield return new WaitForSeconds(0.1f);
            }
            PrintTime();
            yield return new WaitForSeconds(1.0f);
        }
        Pausing = true;
        StartCounter.text = "GameOver";
        GameRunning = false;
        EndGame.SetActive(true);
        //StartCoroutine("GameOver");
    }
    private void PrintTime()
    {
        if (Time < 10)
            GameTimer.text = "0 : 0" + (Time).ToString();
        else if (Time < -1)
            GameTimer.text = "0 : 00";
        else
            GameTimer.text = "0 : " + (Time).ToString();
    }
    IEnumerator GenerateObj()
    {
        float totalGen = InitStates[CurrentStages][0] / GenerateSpd;
        int maxNumber = (int)totalGen;
        int quarterNumber = (int)(maxNumber / 5);
        int[] storageCube = new int[maxNumber];
        Debug.Log(maxNumber);
        Debug.Log(quarterNumber);
        for (int k = 0; k < 5; k++)
        {
            int genNum = InitStates[CurrentStages][1]/5;
            for (int j = 0; j < quarterNumber; j++)
            {
                int output = Random.Range(0, quarterNumber - j);
                if (output > genNum)
                    output = 0;
                else if(genNum>0)
                {
                    output = 1; genNum -= 1;
                }
                storageCube[(k*quarterNumber)+j] = output;
            }
        }
        
        while (GameRunning && Scores< InitStates[CurrentStages][2])
        {
            if (!Pausing)
            {
                if (maxNumber > 0)
                {
                    GameObject.Instantiate(DropObj[storageCube[maxNumber - 1]], DropObjContainer.transform);
                    maxNumber--;
                }
                else
                {
                    int i = Random.Range(0, 2);
                    GameObject.Instantiate(DropObj[i], DropObjContainer.transform);
                }
            }
            yield return new WaitForSeconds(GenerateSpd);
        }
        if (Scores > InitStates[CurrentStages][2]-1) StartCoroutine("GameClear");
    }

    public void AddScore()
    {
        Scores++;
    }

    public void MinusTime()
    {
        if (Time - 2 < 0)
                Time = 0;
        else Time -= 2;
    }

    public void EndgameHandler(int index)
    {
        switch (index)
        {
            case 1:
                GameInit(false);
                break;
            case 2:
                if (CurrentStages < 1)
                    CurrentStages++;
                StartCoroutine(GameOver());
                break;
            default:
                break;
        }
        EndGame.SetActive(false);
    }

    public void PauseHandler()
    {
        Pausing = !Pausing;
    }

    IEnumerator GameOver()
    {
        Pausing = true;
        StartCounter.text = "GameOver";
        GameRunning = false;
        Debug.Log("End");
        yield return new WaitForSeconds(2.0f);
        GameEnd = true;
        GameInit(true);
    }

    IEnumerator GameClear()
    {
        Pausing = true;
        StartCounter.text = "Clear";
        GameRunning = false;
        yield return new WaitForSeconds(2.0f);
        GameEnd = true;
        Debug.Log("Clear");
        CurrentStages = 1;
        GameInit(true);
       
    }

    void GameInit(bool End)
    {
        Scores = 0;
        SweetsNumber = InitStates[CurrentStages][1];
        Time = InitStates[CurrentStages][0];
        PrintTime();
        Pausing = false;
        foreach(Transform childobj in DropObjContainer.transform)
        {
            Destroy(childobj.gameObject);
        }
        TutorialButton.TriggerStart = true;
        if (End)
        {
            MiniGameSceneObj.SetActive(false);
            ScenarioManager.SceneMngIns.SetPause(false);
            GameEnd = false;
            ScenarioManager.SceneMngIns.Once = true;
        }
    }
}
