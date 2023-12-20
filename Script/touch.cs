using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    private Rigidbody2D rd;

    private float jumpForce = 350f;


    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    public void OnClick()
    {
        this.rd.AddForce(transform.up * jumpForce);
    }
}