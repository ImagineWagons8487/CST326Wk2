using System;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 up = new Vector3(0f, 1f, 0f);
        Quaternion posRotation = Quaternion.Euler(45f, 0f, 0f);
        Quaternion negRotation = Quaternion.Euler(-45f, 0f, 0f);
        Vector3 posVector = posRotation * up;
        Vector3 negVector = negRotation * up;
        
        Debug.DrawRay(transform.position, posVector * 2.0f, Color.red);
        Debug.DrawRay(transform.position, negVector * 2.0f, Color.blue);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"contact with {other.gameObject.name}");
    }
}
