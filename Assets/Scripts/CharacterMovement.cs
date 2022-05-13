using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Touch touch;
    private Animator animator;
    [SerializeField] private float rotationSpeed;
    [SerializeField] float charactherSpeed;
    Rigidbody rb;
    private float rotation = 0;
    float limits;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    private void Update()
    {
        Movement();
        SwipeManager();
    }

    private void SwipeManager()
    {
        rotation = Mathf.Clamp(rotation, -25, 25);
        var rot = transform.localEulerAngles;
        rot.y = rotation;
        transform.localEulerAngles = rot;

        if (Input.touchCount > 0)
        {
          
            touch = Input.GetTouch(0);
            if (touch.phase==TouchPhase.Moved)
            {
                if (touch.deltaPosition.x < 0)
                {
                    rotation -= rotationSpeed * Time.deltaTime;
                }
                if (touch.deltaPosition.x > 0)
                {
                    rotation += rotationSpeed * Time.deltaTime;
                }
            }
        }
        else if (Input.GetMouseButton(0))
        {
            
            if (Input.mousePosition.x < 0)
            {
                rotation -= rotationSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x > 0)
            {
                rotation += rotationSpeed * Time.deltaTime;
            }
        }
    }

    private void Movement()
    {
        Vector3 forward = new Vector3(0, 0, 1 * Time.deltaTime * charactherSpeed);

        rb.MovePosition(transform.position + transform.TransformDirection(forward));
    }
}