using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ObserverInterface
{
    void HandleMessages(Object sender,Messages msg);
}
