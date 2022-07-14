using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;

    public float currentHealth;

    public Transform spawnPoint;

    
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageCheck()
    {
        if (currentHealth <= 0 && !gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

        else if (currentHealth <= 0)
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }

}
