using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BallSelector
{


    public static GameObject[] balls;

    public static int index;

    public static bool selectNextBall;

    public static GameObject NextBall;

    public static List<GameObject> ballCleanUp = new List<GameObject>(); 

    public static void initialize()
    {
        randomize();

        if (selectNextBall) { nextBall(); }
    }


    static void nextBall()
    {
        NextBall = balls[index];
        selectNextBall = false;
    } 


    static void randomize()
    {

        index = Random.Range(0, balls.Length);

    }


}

