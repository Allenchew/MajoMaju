using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObj : MonoBehaviour {
    public float MinDropSpd = 0.5f;
    public  float MaxDropSpd = 10f;
    public static bool Pausing = false;
    private float DroppingSpd;
    private float Xpos;
	// Use this for initialization
	void Start () {
        float minspd = MinDropSpd;
        float maxspd = MaxDropSpd;
        RectTransform CharacterSize = transform.GetComponent<RectTransform>();
        float MaxPos = (2048/ 2) - (CharacterSize.sizeDelta.x / 2);
        Xpos = Random.Range(-MaxPos, MaxPos);
        transform.localPosition = new Vector3(Xpos,1000);
        DroppingSpd = Random.Range(minspd,maxspd);
	}
	
	// Update is called once per frame
	void Update () {
        if (!Pausing)
        {
            transform.localPosition -= new Vector3(0, DroppingSpd, 0);
            if (transform.localPosition.y < -1000)
                Destroy(gameObject);
        }
	}
    public void PausePressed()
    {
        Pausing = !Pausing;
    }
}
