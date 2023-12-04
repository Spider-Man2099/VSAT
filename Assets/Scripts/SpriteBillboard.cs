using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    [SerializeField] bool freezeXZAxis = true;
    public System.Random ran = new System.Random();

    // Update is called once per frame
    void Update()
    {
        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        }
        else
        {
            transform.rotation = Camera.main.transform.rotation;
            //transform.rotation = Quaternion.Euler(ran.Next(0, 90), 90f, 0f);
        }
        print("Rotation is working "+ Camera.main.transform.rotation.eulerAngles.y);
    }
}
