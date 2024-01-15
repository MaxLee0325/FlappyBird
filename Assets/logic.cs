using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logic : MonoBehaviour
{
    // Start is called before the first frame update
    public float score;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource zoom;
    public bird bird;

    private void Start()
    {
        bird = GameObject.FindGameObjectWithTag("bird").GetComponent<bird>();

    }

    //play the zooming sound
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && bird.isAlive)
        {
            zoom.Play();
        }
    }

    [ContextMenu("Increase score")]
    public void addScore()
    {
        score += 1;
        scoreText.text = score.ToString("0.#");
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    [ContextMenu("gameOver")]
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

}
