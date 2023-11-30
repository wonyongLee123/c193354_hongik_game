using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPillar : MonoBehaviour
{
    // Start is called before the first frame update*
    private int _hp = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PBullet"))
        {
            _hp -= 1;
        }
    }
}
