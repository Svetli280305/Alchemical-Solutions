using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    public int currentScore;
    public int SceneToLoad;
    public int maxScore;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + currentScore.ToString());
        
        if (currentScore == maxScore)
        {
            SceneManager.LoadScene(SceneToLoad);
            Debug.Log("Potion +1");
        }
    }
}
