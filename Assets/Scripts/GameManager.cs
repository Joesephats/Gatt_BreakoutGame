using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] int bricks = 20;
    [SerializeField] int score = 0;
    [SerializeField] float resetDelay = 1f;
    int currentLevel = 1;

    [SerializeField] TMP_Text livesText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject youWonText;

    [SerializeField] GameObject brickSet1;
    [SerializeField] GameObject brickSet2;
    [SerializeField] GameObject brickSet3;

    [SerializeField] GameObject paddle;
    GameObject clonePaddle;


    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            //NextLevel();
            bricks = 0;
            CheckGameOver();

        }
    }

    public void Setup()
    {
        youWonText.SetActive(false);

        lives = 3;
        bricks = 20;

        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);

        switch (currentLevel)
        {
            case 1:
                Instantiate(brickSet1, transform.position, Quaternion.identity);
                Debug.Log("Level 1 brick spawn");
                break;
            case 2:
                Instantiate(brickSet2, transform.position, Quaternion.identity);
                Debug.Log("Level 2 brick spawn");
                break;
            case 3:
                Instantiate(brickSet3, transform.position, Quaternion.identity);
                Debug.Log("Level 3 brick spawn");
                break;
        }
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWonText.SetActive(true);
            Time.timeScale = .25f;
            Invoke("NextLevel", resetDelay);
        }
        if (lives < 1)
        {
            gameOverText.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void NextLevel()
    {
        if (currentLevel == 3)
        {
            //game end 
        }
        else
        {
            currentLevel++;
            SceneManager.LoadScene($"Level{currentLevel}");
            Setup();
        }

    }
    public void LoseLife()
    {
        lives--;
        livesText.text = $"Lives: {lives}";
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }
    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
    }
    public void DestroyBrick(int brickValue)
    {
        score += brickValue;
        bricks--;
        CheckGameOver();
    }
}
