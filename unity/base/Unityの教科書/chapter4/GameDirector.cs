using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UI部品を使うため

public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject car;
    GameObject flag;
    GameObject distance;
    void Start()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");
    }

    // Update is called once per frame
    void Update()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        this.distance.GetComponent<Text>().text = "ゴールまで" + length.ToString("F2") + "m";
    }
}
