using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class MandelbrotTerrain : MonoBehaviour
{
    [SerializeField]
    double baseX = -1.75;
    [SerializeField]
    double baseY = 0.0;
    [SerializeField]
    double renderArea = 10.0;
    public float speed;
    float size = 500;  //NOTE!

    TerrainData terrainData;

    

    void Start()
    {
        terrainData = GetComponent<Terrain>().terrainData;
        StartCoroutine(UpdateTerrainCoroutine());
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed);
        if (this.transform.position.z >500)
        {
            Debug.Log("out of display");
            this.transform.Translate(0, 0, -1500 );
        }

    }
    IEnumerator UpdateTerrainCoroutine()
    {
        var heights = new float[terrainData.heightmapWidth, terrainData.heightmapHeight];
        
        while (true)
        {
            renderArea *= 0.98;
            var startX = baseX - renderArea / 2.0;
            var startY = baseY - renderArea / 2.0;
            var renderAreaPerWidth = renderArea / terrainData.heightmapWidth;
            var renderAreaPerHeight = renderArea / terrainData.heightmapHeight;

            for (int x = 0; x < terrainData.heightmapWidth; x++)
            {
                for (int y = 0; y < terrainData.heightmapHeight; y++)
                {
                    heights[x, y] = MandelbrotCalculator.Calculate(
                        startX + x * renderAreaPerWidth,
                        startY + y * renderAreaPerHeight);
                    heights[x, y] = heights[x, y] / 10;
                }
            }

            terrainData.SetHeights(0, 0, heights);
            
            yield return null;
        }
    }
}