using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    GameObject ball, clonePaddle;
    public GameObject brickPrefab;
    public GameObject paddle;
    public Text livesText;

    GameObject[] bricks;


    [SerializeField] int columns = 5, rows = 5; 
    [HideInInspector] public int lives =3, bricksInPlay;
    float posX, posY;

    [HideInInspector] public bool inPlay;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        CreateBoard();
        SetupPaddle();
    }

    private void Update()
    {
        Debug.Log(bricksInPlay);
        //allows users to recreate the board if they don't like the color
        if (Input.GetKeyDown(KeyCode.R) && !inPlay)
        {
            DeleteBoard();
            CreateBoard();
        }
    }

    void SetupPaddle()
    {
        clonePaddle = (GameObject)Instantiate(paddle, new Vector3(0, -4.55f, 0), Quaternion.identity);
        ball = GameObject.FindGameObjectWithTag("ball");
    }

    public void DeleteBoard()
    {
        foreach (GameObject brick in bricks)
        {
            Destroy(brick);
        }

    }

    public void CreateBoard()
    {

        posX = transform.position.x;
        posY = transform.position.y;
        float posZ = transform.position.z;
        for (int i = 0; i < rows; i++)
        {
            Color brickColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            for (int j = 0; j < columns; j++)
            {

                GameObject go = (GameObject)Instantiate(brickPrefab, new Vector3(posX + j * 2f, posY + i * .5f, posZ), Quaternion.identity);

                go.GetComponent<Renderer>().material.color = brickColor;
                go.gameObject.transform.parent = gameObject.transform;
            }

        }

        bricks = GameObject.FindGameObjectsWithTag("brick");
        bricksInPlay = bricks.Length;

    }

    public void LoseLife()
    {

        lives--;
        //livesText.text = "Lives: " + lives;
        Destroy(clonePaddle);
        ball = GameObject.FindGameObjectWithTag("ball");
        Destroy(ball);
        Invoke("SetupPaddle", 0.5f);
        CheckGameOver();
    }

    void ResetPaddle()
    {
        if (lives > 0 && bricks.Length > 0)
        {
            clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
            ball = GameObject.FindGameObjectWithTag("ball");
        }
    }

    

    void CheckGameOver()
    {
        //write your code to check for the win or lose condition
    }
}
