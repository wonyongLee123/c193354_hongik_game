using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalEventHandler : MonoBehaviour
{
    public static globalEventHandler Instance { get { return _instance; }}

    private static globalEventHandler _instance = null;

}
