using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{

    private float health = 0f;
    [SerializeField] public float maxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if( health <= 0f)
        {
            health = 0f;
           Die();
        }

    }
    public void Die()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("GameOver");

    }
  
    
}
