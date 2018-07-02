using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MoveScooter : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //セグウェイの傾きを取得
        float z = transform.localEulerAngles.x;

        if (z > 0 && z < 90) {
            //rb.AddForce(0, 0, z);
            rb.transform.localPosition += new Vector3(0, 0, z*0.01f);
        }
        else if (z > 270 && z < 360)
        {
            //rb.AddForce(0, 0, z - 360);
            rb.transform.localPosition += new Vector3(0, 0, (z-360) * 0.01f);
        }
    }
}