using UnityEngine;
using System.Collections;
using System.Collections.Generic; // for List<>
//using System;
using UnityEngine.UI;
using System.IO;


public class graph_renderer : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    float rx,ry,vx,vy;
    Vector2 my2Dpoint_rb;
    int idx_max=5;
    public List<Vector2> my2DPoint_xy = new List<Vector2>();
    public List<Vector2> my2DPoint_xv = new List<Vector2>();

    void DrawLine(List<Vector2> my2DVec, int startPos)
    {
        List<Vector3> myPoint = new List<Vector3>();
        for (int idx = 0; idx < 2; idx++)
        {
            myPoint.Add(new Vector3(my2DVec[startPos + idx].x, my2DVec[startPos + idx].y, 0.0f));
        }

        GameObject newLine = new GameObject("Line");
        LineRenderer lRend = newLine.AddComponent<LineRenderer>();
        lRend.SetVertexCount(2);
        lRend.SetWidth(0.1f, 0.1f);
        Vector3 startVec = myPoint[0];
        Vector3 endVec = myPoint[1];
        lRend.SetPosition(0, startVec);
        lRend.SetPosition(1, endVec);
    }

    void Start()
    {
        List<Vector2> my2DPoint = new List<Vector2>();
        for (int idx = 0; idx < 10; idx++)
        {
            my2DPoint.Add(new Vector2(-15 + 0.2f * idx, Random.Range(0.0f, 5.0f)));
        }
        float x = 0f;
        float y = 0f;
        float z = 40f;
        obj.transform.GetComponent<Rigidbody>().position = new Vector3(x, y, z);
    }

    void Update()
    {
        
        rx = GetComponent<Rigidbody>().position.x;
        ry = GetComponent<Rigidbody>().position.y;
        vx = GetComponent<Rigidbody>().velocity.x;

        Debug.Log(rx);
        Debug.Log(ry);
        Debug.Log(vx);
        Debug.Log(idx_max);

        idx_max += 1;
        obj.transform.GetComponent<Rigidbody>().position = new Vector3(1f*rx, 1f*ry, 10f);
        
        my2DPoint_xv.Add(new Vector2(30+0.5f*rx, 0.25f*vx));
        my2DPoint_xy.Add(new Vector2(1f * rx, 1f * ry));
        int idx_min = (int)(0.95 * idx_max);

        for (int idx = idx_min; idx < idx_max - 1; idx++)
        {
            DrawLine(my2DPoint_xv, /* startPos=*/idx);
            DrawLine(my2DPoint_xy, /* startPos=*/idx);
        }
    }
}