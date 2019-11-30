using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaFoguete : MonoBehaviour
{
    public float height, maxheight = 0.0f, vel1;
    public float fueltime2;
    public Text textmaxheight;
    public Rigidbody rocket;
    public GameObject fuel;
    public GameObject parachute;
    public bool check = false;
    public Vector3 rot;
  
    // Start is called before the first frame update
    void Start()
    {
        rocket = GetComponent<Rigidbody>();
        parachute.GetComponent<MeshRenderer>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        height = rocket.transform.position.y;
        fueltime2 = fuel.GetComponent<AddForce>().fueltime;
        vel1 = fuel.GetComponent<AddForce>().rb.velocity.y;

        if (height >= maxheight && check == false)
        {
            maxheight = height;
            textmaxheight.text = ("Altura máxima: " + maxheight.ToString("f2"));
        }
        else
        {
            if (fueltime2 <= 0.0f && check == false)
            {
                rocket.velocity = new Vector3(0, vel1, 0) * Time.deltaTime;
                check = true;
            }
        }
    }
}


