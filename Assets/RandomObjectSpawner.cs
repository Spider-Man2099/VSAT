using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;


//remember to add collision/rigid body to buildings 
public class RandomObjectSpawner : MonoBehaviour
{
    //Vector3(x, y, z)

    public GameObject[] myObjects;

    float vecX = -85; //float for updating x position of buildings 

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(vecX, 0, Random.Range(-110, 100));

            //Random.Range(-100, 110)
            GameObject newOb = Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
            newOb.AddComponent<BoxCollider>();
            //newOb.AddComponent<Rigidbody>().useGravity = true;
           
            vecX += 5; 
        }
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.V))
        //{
          //  int randomIndex = Random.Range(0, myObjects.Length);
           // Vector3 randomSpawnPosition = new Vector3(Random.Range(-100, 110), 0, Random.Range(-100, 110));

        //for (int i = 0; i < 10; i++)
        //{
          //  Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
           // i += 1;
        //}
        //}
    }
}
