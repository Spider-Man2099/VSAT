using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuilding : MonoBehaviour
{
    public float gap = 2;
    public int height = 0;
    public int minHeight = 1;
    public int maxHeight = 10;
    public GameObject objectToCreate;
    public GameObject spawnner;
    public System.Random ran = new System.Random();

    void Start()
    {
        height = ran.Next(minHeight, maxHeight);
        Vector3 position = spawnner.transform.position;
        for (int i = 0; i < height; i++)
        {
            Instantiate(objectToCreate, position, Quaternion.identity);
            position.y += gap;
        }
    }
}
