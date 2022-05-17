using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.5f;
    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private Transform target;
    private BoxCollider2D boxCollider;
    public GameObject tar;
    private Rigidbody2D rb;

    // Collider

    // Dealing Damage
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Character")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<CharacterHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }


        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Character")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<CharacterHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Character").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
    }
}


