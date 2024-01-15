using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pipe;
    public float spawnRate = 2;
    public float timer = 0;
    public float heightOff = 4;
    public bird bird;

    void Start()
    {
        spawnPipe();
        bird = GameObject.FindGameObjectWithTag("bird").GetComponent<bird>();

    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            //speed up pipe spawn when zooming
            if (Input.GetKey(KeyCode.J) && bird.isAlive)
            {
                timer += (Time.deltaTime * 5);
            }
            else
                timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }
    //randomly spawn pipe
    void spawnPipe() 
    {
        float lowPoint = transform.position.y - heightOff;
        float highPoint = transform.position.y + heightOff;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowPoint, highPoint), 0), transform.rotation);

    }
}
