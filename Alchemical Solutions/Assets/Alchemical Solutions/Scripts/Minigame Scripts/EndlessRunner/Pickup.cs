using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    HighScore hs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void Awake()
    {
        hs = GameObject.Find("Player").GetComponent<HighScore>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy();
        }
        
    }

    private void Destroy()
    {
            hs.currentScore += 1;
            Destroy(gameObject);
    }
}
