using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddForce : MonoBehaviour
{
    public float velTrans;
    public float fueltime= 5.0f;
    public Text textfuel;
    public Rigidbody rb;
    public FixedJoint joint;
    public GameObject apoioleft;
    public GameObject apoioright;
    public AudioClip explosionsound;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joint = GetComponent<FixedJoint>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            DestroyObject(apoioleft);
            DestroyObject(apoioright);
            textfuel.text = ("Voce ainda tem " + fueltime.ToString("f2") + " segundos de combustivel");
            source.PlayOneShot(explosionsound, 1f);
            if (fueltime >= 0.0f)
            {
                rb.AddForce(new Vector3(0, 1, 0) * velTrans * Time.deltaTime, ForceMode.Acceleration);
                fueltime -= Time.deltaTime;
            }
            else
            {
                source.Stop();
                rb.velocity = new Vector3(0, 0, 0) *Time.deltaTime;
                Destroy(joint);
            }           
        }
    }
 }


