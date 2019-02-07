using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameMnger2 : MonoBehaviour {
    public static GameMnger2 Ins2;
    public Sprite[] PictureData = new Sprite[10];
    public GameObject MiniGameObject2;
    public GameObject ShowAnswer;
    public GameObject Bubble;
    public GameObject SelectableUI;
    public float[] PicPos = new float[12] {0,0,0,0,0,0,0,0,0,0,0,0 };
    public Text timer;
    public bool GameEnd = false;

    private int[] StandardIndex = new int[] {0,1,2,3,4,5,6,7,8,9,10,11};
    private int gameTime = 30;
    private int RandomLoop = 5;
    private int SelectLoop = 12;
    private int SelectedAns = 0;
    private List<int> AnswerSheet = new List<int>();
    private List<int> SelectSheet = new List<int>();
    
    private bool Showing = false;
    private Vector3[] SelectablePos;

    void Start() {
        Ins2 = this;
        Bubble.SetActive(false);
        SelectablePos = new Vector3[] {   new Vector3( -PicPos[0], PicPos[2], 0 ),new Vector3( -PicPos[1], PicPos[3], 0 ),
                                          new Vector3( PicPos[1], PicPos[3], 0 ),new Vector3( PicPos[0], PicPos[2], 0 ),
                                          new Vector3( -PicPos[4], PicPos[6], 0 ),new Vector3( -PicPos[5], PicPos[7], 0 ),
                                          new Vector3( PicPos[5], PicPos[7], 0 ),new Vector3( PicPos[4], PicPos[6], 0 ),
                                          new Vector3( -PicPos[8], PicPos[10], 0 ),new Vector3( -PicPos[9], PicPos[11], 0 ),
                                          new Vector3( PicPos[9], PicPos[11], 0 ),new Vector3( PicPos[8], PicPos[10], 0 )};
        Showing = true;
        StartCoroutine("Counting");
        AnswerSheet.Clear();
        SelectSheet.Clear();
        RandomGenerator(SelectLoop, SelectSheet, false);
        RandomGenerator(RandomLoop, AnswerSheet, true);
    }

    // Update is called once per frame
    void Update() {
       
    }
    void RandomGenerator(int Looptimes,List<int> DataSheet,bool ShowAns){
        int[] TempIndex = {0,1,2,3,4,5,6,7,8,9,10,11 };
        for (int i = 0; i < Looptimes; i++) {
            List<int> AnswerAble = new List<int>();
            foreach (int index in TempIndex)
            {
                if (index != -1)AnswerAble.Add(index);
            }
            int RandomIndex = Random.Range(0, 12 - i);
            DataSheet.Add(TempIndex[AnswerAble[RandomIndex]]);
            TempIndex[AnswerAble[RandomIndex]] = -1;
        }
        if (ShowAns)
        {
            StartCoroutine("DisplayAnswer");
        }
    }

    IEnumerator Counting()
    {
        for (int i = 0; i < gameTime; i++)
        {
            yield return new WaitForSeconds(1.0f);
            string PreTime;
            if (gameTime - 1 - i >9)
                PreTime = "0 : ";
            else
                PreTime = "0 : 0";
                timer.text = PreTime + (gameTime - 1 - i).ToString();
        }
        yield return new WaitForSeconds(1.0f);
        GameOver();
    }
    IEnumerator DisplayAnswer()
    {
        Bubble.SetActive(true);
        for (int i = 0; i < 5; i++)
        {
            ShowAnswer.GetComponent<Image>().sprite = PictureData[AnswerSheet[i]];
            yield return new WaitForSeconds(1.0f);
        }
        Bubble.SetActive(false);
        StartCoroutine(SetupSelectable(SelectLoop));
    }
    IEnumerator SetupSelectable(int index)
    {
        for (int i = 0; i < index; i++)
        {
            SelectableUI.transform.GetChild(i).GetChild(0).GetComponentInChildren<Image>().sprite = PictureData[SelectSheet[i]];
        }
        SelectableUI.SetActive(true);
        for(int i = 0; i < 20; i++)
        {
            float movementFloat = i==19?1:(float)i / 19;
            for(int j = 0; j < index; j++)
            {
                SelectableUI.transform.GetChild(j).transform.localPosition = Vector3.Lerp(SelectableUI.transform.localPosition, SelectablePos[j], movementFloat);
            }
            yield return new WaitForSeconds(0.01f);
        }
        
    }
    public void ButtonOnClick(int index)
    {
        
        if (SelectedAns < 5)
        {
            if (SelectSheet[index] == AnswerSheet[SelectedAns])
            {
                Debug.Log("Correct");
                SelectedAns++;
                EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
                if(SelectedAns == 5)
                {
                    GameClear();
                }
            }
            else
            {
                foreach(Transform child in SelectableUI.transform)
                {
                    if (child.gameObject.activeSelf == false) child.gameObject.SetActive(true);
                }
                SelectedAns = 0;
            }
        }
        
    }
    
    private void gameInit()
    {
        foreach(Transform ChildItem in SelectableUI.transform)
        {
            ChildItem.transform.localPosition = SelectableUI.transform.localPosition;
        }
        SelectableUI.SetActive(false);
        SelectedAns = 0;
        timer.text = "20";
        Showing = false;
    }
    private void GameOver()
    {
        GameMnger2.Ins2.GameEnd = true;
        MiniGameObject2.SetActive(false);
    }
    private void GameClear()
    {
        GameMnger2.Ins2.GameEnd = true;
        MiniGameObject2.SetActive(false);
    }
}
