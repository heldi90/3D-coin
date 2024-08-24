using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class partikel_control : MonoBehaviour
{

    public ParticleSystem par;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            par.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "grounde")
        {
            par.Play();
        }
    }
}
