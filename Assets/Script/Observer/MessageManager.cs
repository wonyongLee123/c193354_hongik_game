using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MessageManager : SubjectInterface // Subject
{

    private MessageManager()
    {
    }
    
    private static MessageManager _instance;
    
    public static MessageManager Instance{
        get{
            if(_instance == null) _instance = new MessageManager();
            return _instance;
        }        
    }


    private List<ObserverInterface> observers = new List<ObserverInterface>();

    public void RegisterObserver(ObserverInterface observer)
    {
        if (observer == null) return;
        observers.Add(observer);
    }

    public void RemoveObserver(ObserverInterface observer)
    {
        if (observer == null) return;
        observers.Remove(observer);
    }

    public void SendMessagesToAll(Object sender,Messages msg)
    {
        foreach (var observer in observers)
        {
            observer.HandleMessages(sender,msg);
        }
    }
}
