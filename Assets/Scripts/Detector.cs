using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    Stack stack;
    private int[] smallOnes = { 1, 3, 5, 6, 8, 9, };
    private Animator animator;
    Rigidbody rb;
   
    private void Start()
    {
        animator = GetComponent<Animator>();

        stack = gameObject.GetComponent<Stack>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Border" && stack._fuels !=null )
        {
            animator.SetBool("Fly", true);
            WingPosition();

            StartCoroutine(UseFuel());

            if (stack._fuels.Count <= 2)
            {
                rb.useGravity = true;
                animator.SetBool("Fly", false);

            }
            else
            {
                rb.useGravity = false;
            }

            

        }
    }
    
    private void WingPosition()
    {
        for (int i = 0; i < stack._fuels.Count; i++)
        {

            stack._fuels[0].gameObject.transform.localPosition = new Vector3(stack._fuels.Count*0.1f/2, 0, 0);
            stack._fuels[i].gameObject.transform.localPosition = new Vector3(stack._fuels[0].transform.localPosition.x - i * 0.1f, 1.4f, -0.1f);
            stack._fuels[i].gameObject.transform.localScale = new Vector3(0.1f, 0.7f, 0.1f);
            stack._fuels[i].gameObject.transform.localRotation = Quaternion.Euler(85, 0, 1);
            //stack._fuels[smallOnes[smallOnes.Length.]].gameObject.transform.localScale = new Vector3(0, 0, 0);??

        }
    }
    IEnumerator UseFuel()
    {
        for (int i = stack._fuels.Count-1; i>=1; i--)
        {
            Destroy(stack._fuels[i].gameObject, 0.5f);
            stack._fuels.RemoveAt(i);
            
            yield return new WaitForSeconds(0.5f);


        }



    }
}
