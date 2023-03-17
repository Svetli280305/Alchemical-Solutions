using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    float currentScore;
    [SerializeField] float scoreIncrease;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = currentScore += scoreIncrease * Time.deltaTime;
        
        float outputScore = Mathf.Round(currentScore);
        Debug.Log(outputScore);
        scoreText.SetText("Score: " + outputScore);
    }
}
