using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void DestroySelf()
    {
        GameManager.Instance.Shake();
        Destroy(gameObject);
    }

}
