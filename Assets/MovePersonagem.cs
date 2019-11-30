using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePersonagem : MonoBehaviour
{

    public float velTransl;
    float x, z;
    // Start is called before the first frame update
    void Start()
    {
        velTransl = 5f;
    }
    // Update is called once per frame
    void Update()
    {
        //TECLAS W OU S
        z = Input.GetAxis("Vertical") * velTransl * Time.deltaTime;
        //TECLAS A OU D
        x = Input.GetAxis("Horizontal") * velTransl * Time.deltaTime;
        transform.Translate(x, -z, 0);

    }
}