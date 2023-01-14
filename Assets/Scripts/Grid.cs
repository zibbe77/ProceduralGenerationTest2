using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject myPrefab;
    public int size = 100;
    public float scale = 0.1f;
    public float scale2 = 0.01f;
    public int terrainScale = 10;
    Cell[,] grid;

    void Start()
    {
        float[,] noiseMap = new float[size, size];
        float xOffset = Random.Range(-10000f, 10000f);
        float yOffset = Random.Range(-10000f, 10000f);

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float noiseValue = Mathf.PerlinNoise(x * scale + xOffset, y * scale + yOffset);

                noiseMap[x, y] = noiseValue;
            }
        }

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                int hight = (int)Mathf.Round((noiseMap[x, y] * terrainScale));
                if (hight == 0)
                {
                    hight = -1;
                }
                for (int z = -2; z < hight; z++)
                {
                    Instantiate(myPrefab, new Vector3(x, z, y), Quaternion.identity);
                }
            }
        }
    }
}
