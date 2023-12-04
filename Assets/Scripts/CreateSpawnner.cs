using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpawnner : MonoBehaviour
{
    public float gap = 2;
    public int maxX = 10;
    public int maxZ = 10;
    public GameObject objectToCreate;
    public GameObject objectToCreate2;
    public GameObject spawnner;
    public float x, y, z = 0;
    public float a, b, c = 0;
    public int cluster = 3;
    public int clusterGap = 2;
    int die = 0;
    public System.Random ran = new System.Random();

    void Start()
    {
        Vector3 position = new Vector3(x,y,z);
        Vector3 position2 = new Vector3(a, b, c);

        for (int i = 0; i < maxX;i++)
        {
            for (int j = 0; j < maxZ; j++)
            {
                if (j % cluster != clusterGap && i % cluster != clusterGap)
                {
                    die = ran.Next(1, 3);
                    //print("die= " + die);
                    if (die == 1)
                    {
                        Instantiate(objectToCreate, position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(objectToCreate2, position2, Quaternion.identity);
                    }
                }
                position.z += gap;
                position2.z += gap;
                //print("Changed Z: " + position.z +" Changed C: "+position2.z);
            }
            position.x += gap;
            position2.x += gap;
            position.z = z;
            position2.z = z;
            //print("Changed X: " + position.x+" Changed A: "+position2.x);
            Destroy(this.gameObject);
        }
    }
}
