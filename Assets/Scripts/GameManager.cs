//////////////////////////////////////////////
//Assignment/Lab/Project: BreakoutGame
//Name: Tristin Gatt
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 03/30/2024
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //I had to make some changes to the tutorial code. Making the GameManager a singleton caused a problem where level2 and level3 bricksets would despawn immediately after being instantiated.
    //score variable was made static to persist between levels.


    //game vars
    [SerializeField] int lives = 3;
    [SerializeField] int bricks = 20;
    [SerializeField] static int score = 0;
    [SerializeField] float resetDelay = 1f;

    //ui vars
    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject youWonText;

    //game objects
    [SerializeField] GameObject brickSet1;
    [SerializeField] GameObject brickSet2;
    [SerializeField] GameObject brickSet3;

    [SerializeField] GameObject paddle;
    GameObject clonePaddle;


    public static GameManager Instance { get; private set; }

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();    //spawn bricks and paddle. reset lives and brick counter
        UpdateScore();  //sets score ui
    }

    // Update is called once per frame
    void Update()
    {
        //dev level skip
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextLevel();    //loads next level or win screen.
        }
    }

    //spawn bricks and paddle. reset lives and brick counter
    public void Setup()
    {
        //disables win text
        youWonText.SetActive(false);

        //resets lives and brick counter
        lives = 3;
        bricks = 20;

        //spawn paddle
        clonePaddle = Instantiate(paddle, new Vector3(0, -9.5f, 0), Quaternion.identity);

        //spawns brickset based on level
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                SpawnBricks(brickSet1);
                break;
            case "Level2":
                SpawnBricks(brickSet2);
                break;
            case "Level3":
                SpawnBricks(brickSet3);
                break;
        }
    }

    //spawns a given brickset
    void SpawnBricks(GameObject brickSet)
    {
        Instantiate(brickSet, new Vector3(0, 1, 0), Quaternion.identity);
    }

    //checks if lives or brick counter has hit zero
    void CheckGameOver()
    {
        if (bricks < 1)     //brick case - next level
        {
            youWonText.SetActive(true);
            Time.timeScale = .25f;      //slow motion effect
            Invoke("NextLevel", resetDelay);
        }

        if (lives < 1)      //lives case - game over screen
        {
            gameOverText.SetActive(true);
            Time.timeScale = .25f;      //slow motion effect
            Invoke("Reset", resetDelay);
        }
    }

    //on loss, resets the level
    void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //move to next level
    void NextLevel()
    {
        Time.timeScale = 1f;    //disable slow motion

        //moves to next level based on current level. for level 3 enables win screen.
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                SceneManager.LoadScene($"Level2");
                break;
            case "Level2":
                SceneManager.LoadScene($"Level3");
                break;
            case "Level3":
                youWonText.SetActive(true);
                break;
        }
    }
    public void LoseLife()
    {
        //decrements lives and updates ui
        lives--;
        livesText.text = $"Lives: {lives}";

        //resets the paddle
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);

        //check if lives = 0
        CheckGameOver();
    }

    //spawns paddle
    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
    }

    //called by brick script when a brick breaks
    public void DestroyBrick(int brickValue)
    {
        //update score and ui
        score += brickValue;
        UpdateScore();

        //decrement bricks and check if bricks = 0
        bricks--;
        CheckGameOver();
    }

    //update score ui
    void UpdateScore()
    {
        scoreText.text = $"Score: {score}";
    }
}
