using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingChar : MonoBehaviour {
    public GameObject ShowMinus;
    public GameObject Guide;
    public bool GameStart = false;
    bool Pausing = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void MovingCharacter()
    {
        if (!Guide.activeSelf && !GameMnger.Ins.GameEnd)
        {
            if (!Pausing)
            {
                RectTransform CharacterSize = transform.GetComponent<RectTransform>();
                float MaxPos = (2048 / 2) - (CharacterSize.sizeDelta.x / 2);

                float OutputPos = Input.mousePosition.x - (Screen.width)/2;
              
                if (OutputPos > MaxPos)
                {
                    OutputPos = MaxPos;
                }
                else if (OutputPos < -MaxPos)
                {
                    OutputPos = -MaxPos;
                }
                transform.localPosition = new Vector3(OutputPos, transform.localPosition.y, transform.localPosition.z);
            }
        }

    }
    public void PausePressed()
    {
        Pausing = !Pausing;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bomb" && !GameMnger.Ins.Pausing)
        {
            var A = GameObject.Instantiate(ShowMinus);
            GameMnger.Ins.MinusTime();
        }
        else if (collision.gameObject.tag == "Sweets")
        {
            GameMnger.Ins.AddScore();
        }
        Destroy(collision.gameObject);
    }

}
