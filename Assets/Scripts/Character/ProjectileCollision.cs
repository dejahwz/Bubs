using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{

    private GameManager gameManager;
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    public GameObject Character;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
   void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPosition = currentPosition + velocity * Time.deltaTime;

        RaycastHit2D[] hits = Physics2D.LinecastAll(currentPosition, newPosition);

        foreach(RaycastHit2D hit in hits)
        {
            GameObject other = hit.collider.gameObject;
            if (other != Character)
            {
               if (other.CompareTag("Enemy"))
                {
                    Destroy(other.gameObject);
                    gameManager.UpdateScore(10);
                    break;
                }
             
            }
            
        }

        transform.position = newPosition;
    } 
    
}
