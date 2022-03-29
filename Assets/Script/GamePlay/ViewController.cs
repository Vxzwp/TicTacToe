using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public ChessBooard chessBooard;
    public bool isOver;
    public bool isAI;

    private bool myTurn = true;
    private System.Random rd = new System.Random();

    public GameObject Torus;
    public GameObject Cross;

    private void Update()
    {
        if (!myTurn && isAI && !isOver)
        {
            while (!myTurn)
            {
                var movePoint = rd.Next(1, 9);
                if (!transform.Find(movePoint.ToString()).GetComponent<ClickBox>().isTrigger)
                {
                    transform.Find(movePoint.ToString()).GetComponent<ClickBox>().OnMouseDown();
                }
            }
        }
    }


    //落子,生成棋子&改变数据
    public void MoveInChess(string i)
    {
        if (myTurn)
        {
            Instantiate(Torus, transform.Find(i));
            chessBooard.Modify(i, 1);
        }
        else
        {
            Instantiate(Cross, transform.Find(i));
            chessBooard.Modify(i, 2);
        }

        myTurn = !myTurn;
    }

}
