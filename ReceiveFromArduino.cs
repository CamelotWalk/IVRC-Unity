using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveFromArduino : MonoBehaviour
{

    public SerialHandler serialHandler;
    public Text text;
    public GameObject Segway;

    // Use this for initialization
    void Start()
    {
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
	 * シリアルを受け取った時の処理
	 */
    void OnDataReceived(string message)
    {
        try
        {
            //Arduinoからの値をコンマ区切りでSensor[]にぶち込む
            string[] Sensor = message.Split(',');

            // シリアルの値をテキストに表示
            text.text = "x:" + Sensor[0] + ", " + "y:" + Sensor[1] + "\n"; 

            //Arduinoから来た加速度センサの値をそのままSegwayにぶち込んでいる
            Vector3 angle = new Vector3(float.Parse(Sensor[0]), 0/*- float.Parse(Sensor[1])*/, 0);
            Segway.transform.localRotation = Quaternion.Euler(angle);

        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}