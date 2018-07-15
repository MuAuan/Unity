using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  ////ここを追加////
using System.IO;

public class GetText : MonoBehaviour
{
    public Text m_MyText;
    //public Text m_MyText1;

    //通信開始（http://192.***.***.***:5000/）
    public void connectionStart(string name)
    {
        string POST_URL = "http://192.***.***.***:5000/";
        WWW www = new WWW(POST_URL);
        StartCoroutine("WaitForRequest", www);
    }
    //通信の処理待ち
    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        connectionEnd(www);
    }
    //通信終了後の処理
    private void connectionEnd(WWW www)
    {
        //通信結果をLogで出す
        if (www.error != null)
        {
            //Debug.Log(www.error);
            var strB = www.error.Substring(0, 11);
            GetComponent<Text>().text = strB;
            textSave(strB);
        }
        else
        {
            //通信結果 -> www.text
            //Debug.Log(www.text);
            var strA = www.text;  
            
            GetComponent<Text>().text = strA;
            
            textSave(strA);
        }
    }
    // Update is called once per frame
    void Update()
    {
        connectionStart(name);
    }
    // 引数でStringを渡してやる
    public void textSave(string txt)
    {
        StreamWriter sw = new StreamWriter("LogData.txt", false); //true=追記 false=上書き
        sw.WriteLine(txt);
        sw.Flush();
        sw.Close();
    }
}
