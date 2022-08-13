using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSun : MonoBehaviour
{
    // Start is called before the first frame update
   public  GameObject Light;
   //public GameObject Dark;
    float Spin = 180;

    public float time;

    // Update is called once per frame
    void Update()
    {



    }
    private void FixedUpdate()
    {
        //Light.transform.Rotate(-0.5f, 0, 0);
         
        
            Light.transform.rotation = Quaternion.Euler(new Vector3(time * 7.5f, 0, 0));

        //Dark.transform.Rotate(-0.5f, 0, 0);
        /*
        if (Light.transform.rotation.x < 0)
        {
            Light.transform.Rotate(180, 0, 0);
        }
        if()
        */
    }
}
