using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour
{
    public Button startButton;
    public Button ExitButton;
    public bool gameStarted;

    public GameObject GameHolder;
    public GameObject spawnerHolder;
    public Animator curtainAnim;
    public GameManager manager;

    private void Start()
    {
        GameHolder.SetActive(false);
        spawnerHolder.SetActive(false);
        startButton.onClick.AddListener(starttask);
        ExitButton.onClick.AddListener(exitGame);
        manager = GameObject.FindFirstObjectByType<GameManager>();
    }

    void starttask()
    {
        if  (!gameStarted)
        {
            StartCoroutine(startGame());
          
          
        }
        
    }

    
    // Update is called once per frame
    IEnumerator startGame()
    {
        gameStarted = true;
        GameHolder.SetActive(true);
        curtainAnim.SetBool("open", true);

        yield return new WaitForSecondsRealtime(1);

        manager.GameStarted = true;
        spawnerHolder.SetActive(true);


        yield return null;
    }

    void exitGame ()
    {
        Application.Quit();
    }
}
