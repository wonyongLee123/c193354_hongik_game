using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SubjectInterface
{
    void RegisterObserver(ObserverInterface observer);
    void RemoveObserver(ObserverInterface observer);
    void SendMessagesToAll(Object sender,Messages msg);
}
