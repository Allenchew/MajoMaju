using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnshitsuFunc{

    private bool fading = false;
    
    public IEnumerator SetFadeInOut(Image CurrentMob, Color Org, Color Target, float delay)
    {
        if (!fading)
        {
            fading = true;
            return fadeInOut(CurrentMob, Org,Target, delay);
        }
        return null;
    }
    public void SetColor(Image CurrentMob, Color Target)
    {
        CurrentMob.color = Target;
    }
    public IEnumerator GetPop(GameObject MovTarget, bool AnimDelay, bool initMove)
    {
        return PopOut( MovTarget,  AnimDelay,initMove);
    }
    IEnumerator fadeInOut(Image CurrentMob,Color Org,Color Target,float delay)
    {
        for (int i = 0; i < 10; i++)
        {
            float temp = (float)i / 10;
            if (i == 9) temp = 1;
            CurrentMob.color = Color.Lerp(Org,Target,temp);
            yield return new WaitForSeconds(delay);
        }
        fading = false;
    }
    IEnumerator PopOut(GameObject MovTarget,bool AnimDelay,bool initMove)
    {
        
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
            //BackGroundPic.AccsBack.SetBackGround(Color.white, DarkGrey);
            for (int i = 0; i < 40; i++)
            {
                MovTarget.GetComponent<RectTransform>().sizeDelta += new Vector2(15, 15);
                if (AnimDelay) yield return new WaitForSeconds(0.02f);
            }
        }
        initMove = false;
        AnimDelay = true;
        /*if (boxPicIndex == 1)
        {
            StartCoroutine(BoxEnshitsu.SetFadeInOut(gameObject.GetComponent<Image>(), Color.white, Color.clear, 0.01f));
            BackGroundPic.AccsBack.SetBgColor(Color.white);
            DragonPic.MobPics.GetFadeIn();
        }
        boxPicIndex++;*/
        yield return null;
    }
    
}
