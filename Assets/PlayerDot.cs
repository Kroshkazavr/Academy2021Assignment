using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerDot : MonoBehaviour 
{    
    public float upForce = 10f;
    public Rigidbody2D playerDot;
    public string currentColor;
    public SpriteRenderer sr;

    public Color violet;
    public Color blue;
    public Color red;
    public Color green;

    public static int score = 0;
    public TMP_Text scoreText;
    public static int deaths = -1;
    public TMP_Text deathsNumberText;
    public TMP_Text gameOver;

    public GameObject[] obstacles;
    public GameObject colorSwitcher;

    public GameObject playerDeath;
    public GameObject starCollected;

    private bool isGameOver = false;

    void Start() 
    {
        SetRandomeColor();
        deaths ++;
        deathsNumberText.text = "Deaths: " + deaths.ToString();
    }

    void Update() 
    { 
        if (Input.GetMouseButtonDown(0) && !isGameOver) 
        {
            playerDot.velocity = Vector2.up * upForce;
        }

        if (playerDot.position.y < Camera.main.transform.position.y - 5)
        {
            Debug.Log("GAME OVER!");
            isGameOver = true;
            Instantiate(playerDeath, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            score = 0;
            Invoke("Delay", 1f);   
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {   
        if (collision.tag == "ColorSwitcher")
        {
            SetRandomeColor();
            Destroy(collision.gameObject);

            int randomIndex = Random.Range(0, 2);
            Instantiate(obstacles[randomIndex], new Vector2(transform.position.x, transform.position.y + 5f), transform.rotation);
            return;
        }

        if (collision.tag == "WhiteStar")
        {
            score ++;
            scoreText.text = "Score: " + score.ToString();

            Destroy(collision.gameObject);
            Instantiate(starCollected, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            Instantiate(colorSwitcher, new Vector2(transform.position.x, transform.position.y + 5f), transform.rotation);
            return;        
         }

        if (collision.tag != currentColor)
        {
            Debug.Log("GAME OVER!");
            isGameOver = true;
            Instantiate(playerDeath, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            Invoke("Delay", 1f);     
        }
     }

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
                    sr.color = violet;
                    break;
                case 1:
                    currentColor = "Blue";
                    sr.color = blue;
                    break;
                case 2:
                    currentColor = "Red";
                    sr.color = red;
                    break;
                case 3:
                    currentColor = "Green";
                    sr.color = green;
                    break;
            } 
        } while (currentColor == prevColor);
    }

    void Delay ()
    {   
        gameOver.text = "GAME OVER! Press the left mouse button to contunie";
        if (Input.GetMouseButtonDown(0)) 
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
 }
