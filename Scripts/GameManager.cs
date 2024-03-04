using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{

    public bool GameStarted;
    public bool ResetGame;

    public GameObject[] balls = new GameObject[6];

    public Sprite nextBallImage;

    public Image image; 

    

    private void Start()
    {
        BallSelector.balls = balls;
        BallSelector.selectNextBall = true;
        
    }

    private void Update()
    {
        if (GameStarted)
        {
            BallSelector.initialize();

            if (BallSelector.NextBall != null)
            {
                nextBallImage = BallSelector.NextBall.GetComponent<SpriteRenderer>().sprite;
                image.sprite = nextBallImage;
            }
        }

      if (ResetGame) { CleanUp(); ResetGame = false;  }
    }

    void CleanUp()
    {
        foreach (GameObject ball in BallSelector.ballCleanUp)
        {

            Destroy(ball);
        }

        PointManager man = GameObject.FindFirstObjectByType<PointManager>();
        man.points = 0;
       

    }







}
