using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusTime : MonoBehaviour {
    public GameObject player;
    public GameObject TextShow;
    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        TextShow.transform.position = player.transform.position;
        StartCoroutine("MoveTime");
    }

    // Update is called once per frame
    void Update() {

    }
    IEnumerator MoveTime()
    {
        for (int i = 0; i < 10; i++)
        {
            TextShow.transform.position += new Vector3(0, 1, 0);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
