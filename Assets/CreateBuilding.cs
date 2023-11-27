using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuilding : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnee;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnee, new Vector3(2.0f, 0, 0), spawnPos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
