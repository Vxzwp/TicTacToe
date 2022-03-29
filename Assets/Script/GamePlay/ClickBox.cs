using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBox : MonoBehaviour
{
    public ViewController viewController;

    public bool isTrigger = false;

    public void OnMouseDown()
    {
        if (!viewController.isOver)
        {
            GetComponent<BoxCollider>().enabled = false;
            viewController.MoveInChess(transform.name);
            isTrigger = true;
        }
    }
}
