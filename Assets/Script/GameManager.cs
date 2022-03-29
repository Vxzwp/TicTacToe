using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject chessBoard;
    public GameObject gameOverPanel;
    public bool isAI;

    void OnEnable()
    {
        GameStart.Register(MyGameStart);
        GameReStart.Register(MyGameReStart);
        GameStartAI.Register(MyGameStart_AI);
        GameReStartAI.Register(MyGameReStart_AI);
        GameOver.Register(MyGameOver);
        GameQuit.Register(MyGameQuit);
    }


    void OnDisable()
    {
        GameStart.UnRegister(MyGameStart);
        GameReStart.UnRegister(MyGameReStart);
        GameStartAI.UnRegister(MyGameStart_AI);
        GameReStartAI.UnRegister(MyGameReStart_AI);
        GameOver.UnRegister(MyGameOver);
        GameQuit.UnRegister(MyGameQuit);
    }

    private void MyGameStart()
    {
        isAI = false;
        Instantiate(chessBoard);
        FindObjectOfType<ChessBooard>().GetComponent<ViewController>().isAI = isAI;
    }

    private void MyGameStart_AI()
    {
        isAI = true;
        Instantiate(chessBoard);
        FindObjectOfType<ChessBooard>().GetComponent<ViewController>().isAI = isAI;
    }

    private void MyGameReStart()
    {
        foreach (var item in FindObjectsOfType<ChessBooard>())
        {
            Destroy(item.gameObject);
        }
        MyGameStart();
    }


    private void MyGameReStart_AI()
    {
        foreach (var item in FindObjectsOfType<ChessBooard>())
        {
            Destroy(item.gameObject);
        }
        MyGameStart_AI();
    }

    private void MyGameOver()
    {
        gameOverPanel.SetActive(true);
        FindObjectOfType<ChessBooard>().GetComponent<ViewController>().isOver = true;
    }


    private void MyGameQuit()
    {
        Application.Quit();
    }
}
