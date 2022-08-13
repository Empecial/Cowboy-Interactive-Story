using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool start = false;
    public float duration = 1f;
    public AnimationCurve curve;

    public GameObject pp;
    public GameObject Filter;
    public PlayerControl cp;

    public Material Blood;
    public float Smoth = 1;
    void Update()
    {
        cp = pp.GetComponent<PlayerControl>();

        if(cp.HIT == true)
        {
            cp.HIT = false;
            StartCoroutine(Shaking());
            Smoth = 0.7f;
            Filter.GetComponent<Renderer>().material.SetFloat("_Smoothness", Smoth);
        }

    }
    private void FixedUpdate()
    {
        if(Smoth < 1)
        {
            Smoth += 0.05f;
        }
       
        Filter.GetComponent<Renderer>().material.SetFloat("_Smoothness", Smoth);
    }




    IEnumerator Shaking()
        {
            Vector3 SP = transform.position;
            float ET = 0f;


            while(ET < duration)
            {
                ET += Time.deltaTime;
            float strength = curve.Evaluate(ET / duration);
                transform.position = SP + Random.insideUnitSphere * strength;
                yield return null;

            }
        transform.position = SP;
        }
}
