using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public GameObject player;
    public GameObject camera;
    public int xPos;
    public int yPos;
    public int zPos;


    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(player.transform.position.x, yPos, player.transform.position.z);


    }
}
