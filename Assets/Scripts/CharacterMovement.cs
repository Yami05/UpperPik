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
  public  bool start;
    public GameObject bot;
    AI ai;
    private void Start()
    {
        ai = bot.GetComponent<AI>();
        animator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        animator.SetBool("Idle", true);
        ai.enabled = false;
    }

    private void FixedUpdate()
    {
       
       
        if (start==true)
        {
            transform.Translate(0, 0, 1*Time.deltaTime*charactherSpeed);
           
            
        }
        
       
    }
    private void Update()
    {
        SwipeManager();
        Movement();
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

  
    public void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("isMoving", true);
            start = true;

            ai.enabled = true;
        }
       
    }
    
}