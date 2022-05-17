using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector2 movementDirection;
    public float movementSpeed = 1f;
  
    public float bubble_speed = 1.0f;
    public GameObject BubbleAttackPrefab;
   
    public Rigidbody2D rb;
    public Animator animator;
    
    public GameObject crossHair;
    public float Cross_hair_distance = 1.0f;
    public bool endOfAiming;
    public bool isAiming;
    
    void Start()
    {
  
        boxCollider = GetComponent<BoxCollider2D>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       


    }

    // Update is called once per frame
    void Update()
    {
        
        Inputs();
        Animate();
        Aim();
        Shoot();
    }

    void Inputs()
    {

        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
        movementDirection.Normalize();

        
        endOfAiming = Input.GetButtonUp("Fire1");
        isAiming = Input.GetButton("Fire1");
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
        rb.MovePosition(rb.position + movementDirection * movementSpeed * Time.fixedDeltaTime);
    }

    void Animate()
    {
        if(movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
           
        }
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);
    }

    void Aim()
    {
        if (movementDirection != Vector2.zero)
        {
            crossHair.transform.localPosition = movementDirection * Cross_hair_distance;
        }
    }


    void Shoot()
    {
        Vector2 shootingDirection = crossHair.transform.localPosition;
        shootingDirection.Normalize();

        if (endOfAiming)
        {
            GameObject bubble = Instantiate(BubbleAttackPrefab, transform.position, Quaternion.identity);
            ProjectileCollision bubbleScript = bubble.GetComponent<ProjectileCollision>();
            bubbleScript.velocity = shootingDirection * bubble_speed;
            bubbleScript.Character = gameObject; 
            bubble.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            Destroy(bubble, 2.0f);
        }
    }
    
 
}
