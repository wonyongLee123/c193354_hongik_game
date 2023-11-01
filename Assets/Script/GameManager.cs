using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/*
 * 
 * 
 * 
 */
public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void Start()
    {
        MessageManager.Instance.SendMessagesToObserver(Messages.MsgTest);
    }

    private void Update()
    {
        if (Input.GetKeyDown("z")) 
        {
            MessageManager.Instance.SendMessagesToObserver(Messages.MsgTest);
        }
    }
}
