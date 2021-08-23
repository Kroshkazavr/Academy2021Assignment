using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Main game functionality is implemented in this class.
/// </summary>
public class PlayerDot : MonoBehaviour 
{    
    public float upForce = 10f;
    public Rigidbody2D playerDot;
    public string currentColor;
    public SpriteRenderer spriteRenderer;

    public Color violet;
    public Color blue;
    public Color red;
    public Color green;

    public static int score = 0;
    public TMP_Text scoreText;
    public static int deaths = -1;
    public TMP_Text deathsNumberText;
    public TMP_Text gameOverText;

    public GameObject[] obstacles;
    public GameObject colorSwitcher;

    public GameObject playerDeath;
    public GameObject starCollected;

    private bool isGameOver = false;
    
    // Initialisation: setup ball's color and increase deapths counter.
    void Start() 
    {
        SetRandomeColor();
        deaths ++;
        deathsNumberText.text = "Deaths: " + deaths.ToString();
    }

    // Ball's movements and ending game verification.
    void Update() 
    { 
        if (Input.GetMouseButtonDown(0) && !isGameOver) 
        {
            playerDot.velocity = Vector2.up * upForce;
        }
        // End game if ball is not visible.
        if (playerDot.position.y < Camera.main.transform.position.y - 5)
        {
            Debug.Log("GAME OVER!");
            isGameOver = true;
            Instantiate(playerDeath, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            score = 0;
            Invoke("Delay", 1f);   
        }

    }

    // Ball's collision behaviour. 
    private void OnTriggerEnter2D(Collider2D collision) 
    {   
        // Collision with color switcher.
        if (collision.tag == "ColorSwitcher")
        {
            SetRandomeColor();
            Destroy(collision.gameObject);

            int randomIndex = Random.Range(0, 2);
            Instantiate(obstacles[randomIndex], new Vector2(transform.position.x, transform.position.y + 5f), transform.rotation);
            return;
        }

        // Collision with the white star.
        if (collision.tag == "WhiteStar")
        {
            score ++;
            scoreText.text = "Score: " + score.ToString();

            Destroy(collision.gameObject);
            Instantiate(starCollected, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            Instantiate(colorSwitcher, new Vector2(transform.position.x, transform.position.y + 5f), transform.rotation);
            return;        
         }

        // Game should be ended when ball and obsticle have different colors.
        if (collision.tag != currentColor)
        {
            Debug.Log("GAME OVER!");
            isGameOver = true;
            Instantiate(playerDeath, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            Invoke("Delay", 1f);     
        }
     }

    // Ball's color setup.
    void SetRandomeColor()
    {
        string prevColor = currentColor;
        do 
        {
            int random = Random.Range(0, 4);

            switch (random)
            {
                case 0:
                    currentColor = "Violet";
                    spriteRenderer.color = violet;
                    break;
                case 1:
                    currentColor = "Blue";
                    spriteRenderer.color = blue;
                    break;
                case 2:
                    currentColor = "Red";
                    spriteRenderer.color = red;
                    break;
                case 3:
                    currentColor = "Green";
                    spriteRenderer.color = green;
                    break;
            } 
        } while (currentColor == prevColor);
    }

    // Delay for the scene update.
    void Delay ()
    {   
        gameOverText.text = "GAME OVER! Press the left mouse button to contunie";
        // Player will be able to restart the game by pressing the left mouse button.
        if (Input.GetMouseButtonDown(0)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
 }
