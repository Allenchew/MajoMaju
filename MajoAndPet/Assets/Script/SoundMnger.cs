using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SoundMnger : MonoBehaviour {
    #region singleton
    public static SoundMnger SoundInstance;
    private void Awake()
    {
        if (SoundInstance == null)
        {
            SoundInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (SoundInstance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public Camera cam;
    public AudioClip Opening;
    public AudioClip[] Bgms = new AudioClip[6];
    public AudioClip[] DragonSE = new AudioClip[13];
    public AudioClip[] DragonVocal = new AudioClip[13];
    public AudioClip[] GryphonVocal = new AudioClip[19];
    public Slider BgmVolume;
    public Slider SeVolume;
    public Slider VocalVolume;
    public string CurrentScene;
    public string NextScene;
    public int StoryMode;
    public bool StartPlay = false;
    public GameObject SoundPanel;

    private AudioSource BgmPlaying;
    private AudioSource SEPlaying;
    private AudioSource VocalPlaying;
    private bool IsScaling = false;
    private bool isScaled = false;
    private bool StartAdj = false;
    private bool testPlaying = false;
    private float BgmStepping = 0.01f;

   
    void Start () {
        cam = Camera.main;
        BgmPlaying = cam.GetComponent<AudioSource>();
        BgmPlaying.clip = Opening;
        CurrentScene = SceneManager.GetActiveScene().name;
        NextScene = SceneManager.GetActiveScene().name;
        StartCoroutine(ScalingBgm(BgmStepping));
    }

    void Update()
    {
        //bgmの再生時に音量を増加する処理
        if (StartAdj)
        {
            BgmStepping = BgmVolume.value /100;
            SEPlaying.volume = SeVolume.value;
            VocalPlaying.volume = VocalVolume.value;
            if(BgmPlaying.isPlaying && BgmPlaying.volume != BgmVolume.value && SoundPanel.activeSelf)
            {
                BgmPlaying.volume += BgmStepping*100-BgmPlaying.volume;
                Debug.Log("test");
            }
        }
        //シーンのロード
        if(CurrentScene != NextScene)
        {
            if (SceneManager.GetActiveScene().name == "Main")
            {
                if (StartPlay)
                {
                    CurrentScene = NextScene;
                    StartAdj = true;
                    SeVolume.value = 1;
                    VocalVolume.value = 1;
                    BgmVolume.value = 1;
                    InitNewScene();
                }
            }
        }
        //
        else if(CurrentScene == "Title")
        {
            if (BgmPlaying.time > 87 && !isScaled)
            {
                isScaled = true;
                StartCoroutine(ScalingBgm(-BgmStepping));
            }
            if (!BgmPlaying.isPlaying)
            {
                BgmPlaying.Play();
                isScaled = false;
                StartCoroutine(ScalingBgm(BgmStepping));
            }
        }
    }
    //ドラゴンの音声を流す
    public void GetVocalPlay(int index)
    {
        VocalPlaying.clip = DragonVocal[index];
        VocalPlaying.Play();
    }
    //グリフォンの音声を流す
    public void GetGryphonVocal(int index)
    {
        VocalPlaying.clip = GryphonVocal[index];
        VocalPlaying.Play();
    }
    //SEを流す
    public void GetSePlay(int index)
    {
        SEPlaying.clip = DragonSE[index];
        SEPlaying.Play();
    }
    //BGMを流す
    public void GetBgmPlay(int index)
    {
        BgmPlaying.clip = Bgms[index];
        BgmPlaying.Play();
    }
    //BGMを止める
    public void StopBgm()
    {
        BgmPlaying.Stop();
    }
    //SEを止める
    public void StopSe()
    {
        SEPlaying.Stop();
    }
    
    public AudioSource GetSe()
    {
        return SEPlaying;
    }
    public void ReloadSound()
    {
        Destroy(gameObject);
    }
    
    public void GetScaling(bool Increment)
    {
        Debug.Log("called");
        if (!IsScaling)
        {
            Debug.Log("not scalling");
            if (Increment)
            {
                StartCoroutine(ScalingBgm(BgmStepping));
                Debug.Log("incre");
            }
            else
            {
                StartCoroutine(ScalingBgm(-BgmStepping));
                Debug.Log("decre");
            }
        }
    }
    //新たなシーンをセットアップ
    void InitNewScene()
    {
        cam = Camera.main;
        BgmPlaying = cam.GetComponent<AudioSource>();
        BgmPlaying.volume = 0;
        BgmPlaying.clip = Bgms[0];
        BgmPlaying.Play();
        SEPlaying = cam.transform.GetChild(0).GetComponent<AudioSource>();
        SEPlaying.clip = DragonSE[0];
        SEPlaying.Play();
        VocalPlaying = cam.transform.GetChild(1).GetComponent<AudioSource>();
        StartCoroutine(ScalingBgm(BgmStepping));
        BgmPlaying.loop = true;
    }
    //音量を調整する
    IEnumerator ScalingBgm(float Stepping)
    {
        IsScaling = true;
        for (int i = 0; i <100; i++)
        {
            BgmPlaying.volume += (Stepping);
            yield return new WaitForSeconds(0.03f);
        }
        if(Stepping<0)
            BgmPlaying.Stop();
        Debug.Log("ran");
        IsScaling = false;
    }
    public void ShowSound()
    {
        SoundPanel.SetActive(!SoundPanel.activeSelf);
        if (SoundPanel.activeSelf)
        {
            ScenarioManager.SceneMngIns.SetPause(true);
        }
        else
        {
            ScenarioManager.SceneMngIns.SetPause(false);
        }
        if (testPlaying)
        {
            BgmPlaying.Stop();
            SEPlaying.Stop();
            VocalPlaying.Stop();
        }
    }

    public void TestPlay(int index)
    {
        if (StartPlay)
        {
            switch (index)
            {
                case 0:
                    if (!BgmPlaying.isPlaying)
                    {
                        BgmPlaying.clip = Bgms[0];
                        BgmPlaying.Play();
                        testPlaying = true;
                    }
                    break;
                case 1:
                    if (!SEPlaying.isPlaying)
                    {
                        SEPlaying.clip = DragonSE[0];
                        SEPlaying.Play();
                    }
                    break;
                case 2:
                    if (!VocalPlaying.isPlaying)
                    {
                        VocalPlaying.clip = DragonVocal[0];
                        VocalPlaying.Play();
                    }
                    break;
            }
        }
    }
}
