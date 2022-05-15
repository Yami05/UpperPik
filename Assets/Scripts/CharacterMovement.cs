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
    bool start;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        animator.SetBool("Idle", true);

    }

    private void FixedUpdate()
    {
        if (start==true)
        {
            transform.Translate(0, 0, 1*Time.deltaTime*charactherSpeed);
            //Vector3 forward = new Vector3(0, 0, 1 * Time.deltaTime * charactherSpeed); it is not working with the mouse click
            
        }
        Movement();
        SwipeManager();
       
    }

    private void SwipeManager()
    {
        rotation = Mathf.Clamp(rotation, -30, 30);
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
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("isMoving", true);
            start = true;

            
        }
       
    }
    
}