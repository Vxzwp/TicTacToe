using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBooard : MonoBehaviour
{
    //用数组存储棋盘信息
    //0：无棋子；1：圈圈；2：叉叉
    private int[,] chess = new int[3, 3];

    //修改数据并且进行一次检测
    public void Modify(string index, int chess)
    {
        var horizontal = (int.Parse(index) - 1) / 3;
        var vertical = (int.Parse(index) - 1) % 3;

        this.chess[horizontal, vertical] = chess;

        //游戏结束
        if (IsOver(this.chess) != 0)
        {
            GameOver.Trigger();
            // Debug.Log("游戏结束   " + IsOver(this.chess) + "胜利");
        }
    }

    //胜负检测
    private int IsOver(int[,] chess)
    {
        for (int i = 0; i < 3; i++)
        {
            //横排
            if (chess[i, 0] == chess[i, 1] && chess[i, 0] == chess[i, 2] && chess[i, 0] != 0)
            {
                if (chess[i, 0] == 1) return 1;
                if (chess[i, 0] == 2) return 2;
            }

            //竖排
            if (chess[0, i] == chess[1, i] && chess[0, i] == chess[2, i] && chess[0, i] != 0)
            {
                if (chess[0, i] == 1) return 1;
                if (chess[0, i] == 2) return 2;
            }
        }

        //斜排
        if (chess[0, 0] == chess[1, 1] && chess[0, 0] == chess[2, 2] && chess[0, 0] != 0)
        {
            if (chess[0, 0] == 1) return 1;
            if (chess[0, 0] == 2) return 2;
        }
        if (chess[0, 2] == chess[1, 1] && chess[0, 2] == chess[2, 0] && chess[0, 2] != 0)
        {
            if (chess[0, 2] == 1) return 1;
            if (chess[0, 2] == 2) return 2;
        }

        //尚未分出胜负
        foreach (var item in chess)
        {
            if (item == 0)
            {
                return 0;
            }
        }

        //平局
        return 3;
    }

    //外部访问
    public int Outcome()
    {
        Debug.Log(IsOver(chess));
        return IsOver(chess);
    }
}
