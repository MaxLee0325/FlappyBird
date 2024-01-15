using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mid : MonoBehaviour
{
    // Start is called before the first frame update
    public logic logicx;
    public AudioSource scoreSound;
    public bird bird;

    void Start()
    {
        logicx = GameObject.FindGameObjectWithTag("logic").GetComponent<logic>();
        bird = GameObject.FindGameObjectWithTag("bird").GetComponent<bird>();
    }
    //giving score 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bird.isAlive)
        {
            logicx.addScore();
            scoreSound.Play();
        }
     
    }
}
