using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PaddleManagerScript : MonoBehaviour
{
    public GameObject leftPaddle, rightPaddle;

    private float lMove, rMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lPos = leftPaddle.transform.position;
        lPos = new Vector3(lPos.x, lPos.y, lPos.z + Time.deltaTime * lMove * 8.0f);
        lPos.z = Math.Clamp(lPos.z, -7.5f, 7.5f);
        leftPaddle.transform.position = lPos;

        Vector3 rPos = rightPaddle.transform.position;
        rPos = new Vector3(rPos.x, rPos.y, rPos.z + Time.deltaTime * rMove * 8.0f);
        rPos.z = Math.Clamp(rPos.z, -7.5f, 7.5f);
        rightPaddle.transform.position = rPos;
    }

    public void OnMoveLeftPaddle(InputAction.CallbackContext context)
    {
        lMove = context.ReadValue<float>();
    }
    
    public void OnMoveRightPaddle(InputAction.CallbackContext context)
    {
        rMove = context.ReadValue<float>();
    }
}
