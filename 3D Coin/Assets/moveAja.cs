using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAja : MonoBehaviour
{

    Rigidbody rb;
    public float kecepatan;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 gerakan = new Vector3(horizontal, 0, vertical);
        rb.AddForce(gerakan * kecepatan);
    }
}
