using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameControll : MonoBehaviour {
    [SerializeField]
    private PlayerHealth playerHealth;
    [SerializeField]
    private Enemyhealth enemyHealth;
    GUIStyle GUIStyle = new GUIStyle();
    [SerializeField]
    private PlayerShoot playerShoot;
    [SerializeField]
    private GameObject[] enemy;
    private float spawnTime = 3f;
    [SerializeField]
    private Transform[] spawnPoint;
    [SerializeField]
    private EnemyAttack enemyAttack;
    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private Text scoreText;
    public  int score;
    private int i = 0;
    private bool toggleButton = false;
    private bool guiEnabled = true;
    [SerializeField]
    private float timeToSpawnBunny = 10f;
    private float timer = 0f;
    public int stopTime = 0;
    [SerializeField]
    private GameObject pauseMenu;
    
    private void Start()
    {
        ZombiNormalPower();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        score = 0;
        timer = 0;
        pauseMenu.SetActive(false);
        playerObject.SetActive(true);
    }
    void OnGUI()
    { 
        GUIStyle.fontSize = 25;
        GUIStyle.normal.textColor = Color.red;

        if (guiEnabled)
        {
            GUI.Label(new Rect(0, 50, 100, 50), playerShoot._ammoMagazine.ToString() + "/" + playerShoot.ammo, GUIStyle);

            GUI.Label(new Rect(0, 0, 100, 50), "HEALTH: " + playerHealth.currentHealth + "\n" + "SCORE: " + ScoreManager.score.ToString(), GUIStyle);
        }
    }
    private void Update()
    {
        #region Stanje igrača
        scoreText.text = score.ToString();
        if (!ScoreManager.playerDead)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (toggleButton)
                {
                    
                    PauseGame();
                    Cursor.visible = true;

                }
                else
                {
                    ResumeGame();
                    Cursor.visible = false;
                }
                toggleButton = !toggleButton;

            }
        }
        #endregion
        if (ScoreManager.bunnyCounter == 0)
            ZombiNormalPower();
        
        score = ScoreManager.score;
        timer += Time.deltaTime;
        if (timer > timeToSpawnBunny)
        {
            timer = 0;
            i = 1;
            Spawn();
            ScoreManager.bunnyCounter++;
            PowerUpZombies();
        }
        i = 0;  
    }
    private void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoint.Length);
        Instantiate(enemy[i], spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation) ;
    }

    private void PowerUpZombies()
    {
        enemyHealth.startingHealth = enemyHealth.health * (ScoreManager.bunnyCounter + 1);
        enemyAttack.attackDamage = enemyAttack.damage * (ScoreManager.bunnyCounter + 1);
    }
        
    private void ZombiNormalPower()
    {
        enemyHealth.startingHealth = enemyHealth.health;
        enemyAttack.attackDamage = enemyAttack.damage;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        ScoreManager.isPaused = false;
        guiEnabled = false;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        ScoreManager.isPaused = true;
        guiEnabled = true;
    }
    
}
