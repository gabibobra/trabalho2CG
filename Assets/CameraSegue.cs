using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public GameObject astronauta;
    public float control;
    public float control2;
    public Vector3 Distance;
    public Vector3 Distance2;
    public bool mudacamera = false;

    // Start is called before the first frame update
    void Start()
    {
        control = target.position.x;
        control2 = target2.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (!mudacamera)
        {
            transform.position = new Vector3(target.position.x, target.position.y, target.position.z) + Distance;
            if (Input.GetKey(KeyCode.Space))
            {
                muda();
            }
        }
        else
        {
            DestroyObject(astronauta);
            transform.position = new Vector3(target2.position.x, target2.position.y, target2.position.z) + Distance2;
        }
    }
    void muda()
    {
        mudacamera = true;
    }
}