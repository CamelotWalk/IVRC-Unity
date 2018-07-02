using UnityEngine;
using System.Collections;

public class SendToArduino : MonoBehaviour
{
    public SerialHandler serialHandler;
    public GameObject Segway;

    void Update()
    {
        float SegwayX = Segway.transform.eulerAngles.x;
        Debug.Log(SegwayX);

        //Arduinoに文字を送る

        //セグウェイの傾きに応じて
        if (SegwayX >= 0 && SegwayX < 45)
        {
            serialHandler.Write("L");
        }
        else　if(SegwayX >= 315 && SegwayX < 360)
        {
            serialHandler.Write("H");
        }
        else
        {
            serialHandler.Write("0");
        }

        /*
        //キー入力
        if (Input.GetKeyDown(KeyCode.S))
        {
            serialHandler.Write("0");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            serialHandler.Write("1");
        }
        */
    }
}