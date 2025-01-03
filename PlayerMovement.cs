using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float playerSpeed = 5f;
    public float vertical;
    public float horizontal;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 playerMovement = new Vector3(horizontal, vertical, 0).normalized;

        transform.position += playerSpeed * Time.deltaTime * playerMovement;

        if (Mathf.Abs(vertical) > 0 || Mathf.Abs(horizontal) > 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning",false);
        }
    }
}
