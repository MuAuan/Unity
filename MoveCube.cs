using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class MoveCube : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private GameObject obj2;
    
    private float x;
    private float y;
    private float z;
    private float x1;
    private float y1;
    private float z1;
    private float x01;
    private float y01;
    private float z01;
    
    private float fc;
    public Text m_MyText;

    // Use this for initialization
    void Start()
    {
        fc = 1f;
        x1 = 0f;
        y1 = 0f;
        z1 = 10f;
    }
    // Update is called once per frame
    void Update()
    {
        // タイマーの生成
        var timer = new Timer();
        timer.Elapsed += new ElapsedEventHandler(OnElapsed_TimersTimer);
        timer.Interval = 10000;
        // タイマーを開始
        timer.Start();
        // タイマーを停止
        timer.Stop();
        
        float s = float.Parse(m_MyText.text.Substring(0,10));　
        float s1 = float.Parse(m_MyText.text.Substring(startIndex: 11, length: 10));
        float s2 = float.Parse(m_MyText.text.Substring(startIndex: 22, length: 10));
        x = 2f * s;  // Mathf.Sin(s);
        y = 2f * s1;  // Mathf.Cos(s);
        z = 2f * s2;  // obj.transform.GetComponent<Rigidbody>().position.z;
        x1 = 0f * Mathf.Cos(s);
        y1 = 0f * Mathf.Sin(s1);
        z1 = 20f;  // obj2.transform.GetComponent<Rigidbody>().position.z; 
        obj.transform.GetComponent<Rigidbody>().position = new Vector3(x, y, z);
        obj2.transform.GetComponent<Rigidbody>().position = new Vector3(x1, y1, z1);
        
    }
    static void OnElapsed_TimersTimer(object sender, ElapsedEventArgs e)
    {
    }
}