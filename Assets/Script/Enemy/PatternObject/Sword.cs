using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private float swordLifetime = 1.5f;
    void Start()
    {
        Invoke("DestroySelf",swordLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

}
