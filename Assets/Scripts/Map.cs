﻿using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random;
using Alice;
public class Map : MonoBehaviour
{
    public GameObject background;             //背景图片
    public GameObject[] door;                //门的图片

    public int[,] mapBoard { get; private set; }
    private MapAlgo mapalgo = new MapAlgo();


    private void Init()
    {
        mapBoard = mapalgo.create();
    }

    //生成地图
    public void CreateMap()
    {
        Init();
        CreateBackground();
    }
    //生成地图背景
    private void CreateBackground()
    {
        for (int i = 0; i < MapAlgo.GetX(); i++)
        {
            for (int j = 0; j < MapAlgo.GetY(); j++)
            {
                if (mapBoard[i, j] == 0)
                {
                    Instantiate(background, new Vector3(j * GameManager.instance.px_x, i * GameManager.instance.px_y, 10f), Quaternion.identity);
                    CreateDoor(i, j);
                }
            }
        }
    }

    //生成门
    private void CreateDoor(int i, int j)
    {
        if ((i > 0) && (mapBoard[i - 1, j] == 0))
        {
            Instantiate(door[1], new Vector3(j * GameManager.instance.px_x, i * GameManager.instance.px_y - 2.8f, 9f), Quaternion.identity);
        }
        if ((i < MapAlgo.GetX() - 1) && (mapBoard[i + 1, j] == 0))
        {
            Instantiate(door[0], new Vector3(j * GameManager.instance.px_x, i * GameManager.instance.px_y + 2.8f, 9f), Quaternion.identity);
        }
        if ((j > 0) && (mapBoard[i, j - 1] == 0))
        {
            Instantiate(door[2], new Vector3(j * GameManager.instance.px_x - 4.9f, i * GameManager.instance.px_y, 9f), Quaternion.identity);
        }
        if ((j < MapAlgo.GetY() - 1) && (mapBoard[i, j + 1] == 0))
        {
            Instantiate(door[3], new Vector3(j * GameManager.instance.px_x + 4.9f, i * GameManager.instance.px_y, 9f), Quaternion.identity);
        }
    }

}
