using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 5;
    public float deadZone = -15;
    public bird bird;
    
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("bird").GetComponent<bird>();
    }

    // Update is called once per frame
    void Update()
    {
        //zoom speed up the pipe movement
        if (Input.GetKey(KeyCode.J) && bird.isAlive)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime * 5;
        }
        else
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }
        if(transform.position.x < deadZone)
        {
            Debug.Log("pipe deleted");
            Destroy(gameObject);
        }
    }
}
