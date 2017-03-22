using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    private bool isDamage = false;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameControll gameControll;
  
    
     


    private void Awake()
    {
   
        currentHealth = startingHealth;
        menu.SetActive(false);
        
    }
    private void Update()
    {
        if (ScoreManager.playerDead)
            Cursor.visible = true;
        if (isDamage)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        isDamage = false;

    }

    public void TakeDemage(int amount)
    {
        isDamage = true;
        currentHealth -= amount;
        if (currentHealth <= 0 )
        {
            ScoreManager.playerDead = true;
            Death();
        }
    }
    private void Death()
    {
        menu.SetActive(true);
        gameControll.PauseGame();
        
        
    }
        
        
        

    
   
    
}
