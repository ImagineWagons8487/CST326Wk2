using System;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Vector3 direction;
    private float timePassed;

    private float speed;

    public PaddleManagerScript paddleManager;

    public Material mat;

    public CameraScript cScript;

    public GameObject ballParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = new Vector3(1f, 0f, 0f);
        speed = 10f;
        mat.color = Color.white;
        timePassed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * (Time.deltaTime * speed);
        timePassed += Time.deltaTime;
        if (timePassed >= .1f/speed)
        {
            Instantiate(ballParticle, transform.position, Quaternion.identity);
            timePassed = 0;
        }
    }

    public void ResetBall(float dir)
    {
        transform.position = new Vector3(0, 1, 0);
        direction = new Vector3(dir, 0, 0);
        speed = 10f;
        mat.color = Color.white;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "LPaddle" || other.gameObject.name == "RPaddle")
        {
            speed *= 1.4f;
            direction *= -1;
            float max = paddleManager.max;
            
            ContactPoint p = other.GetContact(0);
            
            float contactDiff = p.point.z - other.gameObject.transform.position.z;
            float anglePercent = contactDiff / max;
            float bounceAngle = 45 * anglePercent;
            if (direction.x > 0)
                bounceAngle *= -1;
            Quaternion rotation = Quaternion.Euler(0f, bounceAngle, 0f);
            direction = rotation * direction;
            if (mat.color.g == 0)
            {
                mat.color = new Color(mat.color.r + 3, 0, 0, 1);
            }
            else
            {
                mat.color = new Color(1, mat.color.g - .2f, mat.color.b - .2f, 1);
            }
            cScript.Shake(speed);
        }
        else
        {
            direction.z *= -1;
            cScript.Shake(speed/3);
        }
    }
}
