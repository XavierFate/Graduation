using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Advertisements;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    [SerializeField] InterstitialAds interstitialAds;

    public static GameController instance;
    public GameObject gameOverText;
    public TMP_Text scoreText;
    public Button button;
    public bool gameOver = false;
    public float moveSpeed = -1.5f;

    public static int score = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            if (gameOver == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1)))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
    }

    public void BallScored()
    {
        if(gameOver)
        {
            return;
        }
        score++;
        scoreText.text = score.ToString();
    }
    public void BallDied()
    {
        interstitialAds.ShowAd();
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
