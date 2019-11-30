using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteController : MonoBehaviour

{
    public Rigidbody paraquedas;
    public GameObject body;
    public float distancia;
    public float abertura;
    private bool deployed;
    private bool check2;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray distancia = new Ray(transform.position, Vector3.down);
        check2 = body.GetComponent<ControlaFoguete>().check;
        Debug.DrawRay(transform.position, Vector3.down);
        if (!deployed)
        {           
                if (Physics.Raycast(distancia, out hit, abertura))
                {
                    if (hit.collider.tag == "cube")
                    {
                        DeployParaquedas();
                    }
                }
        }
        else
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(90f, 0, 0), 5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90f, 0), 1f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90f, 0), 1f * Time.deltaTime);
            }
        }
    }
    void DeployParaquedas()
    {
        if (check2 == true)
        {
            paraquedas.GetComponent<MeshRenderer>().enabled = true;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(90f, 0, 0), 5f * Time.deltaTime);
            paraquedas.drag = 20f;
            deployed = true;
        }
    }
}
