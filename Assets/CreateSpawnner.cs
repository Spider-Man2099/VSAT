using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpawnner : MonoBehaviour
{
    public float gap = 2;
    public int maxX = 10;
    public int maxZ = 10;
    public GameObject objectToCreate;
    public GameObject spawnner;
    public float x, y, z = 0;
    public int cluster = 3;
    public int clusterGap = 2;

    void Start()
    {
        Vector3 position = new Vector3(x,y,z);
        for (int i = 0; i < maxX;i++)
        {
            for (int j = 0; j < maxZ; j++)
            {
                if (j%cluster != clusterGap && i%cluster != clusterGap)
                {
                    Instantiate(objectToCreate, position, Quaternion.identity);
                }
                position.z += gap;
                print("Changed Z: " + position.z);
            }
            position.x += gap;
            position.z = z;
            print("Changed X: " + position.x);
        }
    }
}
