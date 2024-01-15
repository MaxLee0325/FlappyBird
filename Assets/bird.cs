using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour{

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public logic logicx;
    public bool isAlive = true;
    public AudioSource jump;
    public AudioSource hit;

    // Start is called before the first frame update
    void Start(){
        logicx = GameObject.FindGameObjectWithTag("logic").GetComponent<logic>();
    }

    // Update is called once per frame
    void Update(){
        //giving zooming bonus
        if (Input.GetKey(KeyCode.J) && isAlive)
        {
            logicx.score += (Time.deltaTime);
            Debug.Log(isAlive);
            logicx.scoreText.text = logicx.score.ToString("0.#");
        }
        //flap up
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            jump.Play();
        }
        //fall off edge, game over
        if (transform.position.y < -7 || transform.position.y > 7)
        {
            logicx.gameOver();
            isAlive = false;
        }
        //stop bird from falling
        if(transform.position.y < -30)
        {
            myRigidbody.gravityScale = 0;
            myRigidbody.velocity = Vector2.zero;
        }
        //rotation control
        Vector2 velo = myRigidbody.velocity;
        if(velo.y > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 20);
        }
        else
        {
            transform.Rotate(Vector3.forward, -40 * Time.deltaTime);
        }
    }
    //game over on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("over!!");
        hit.Play();
        logicx.gameOver();
        isAlive = false;
    }

    
}
