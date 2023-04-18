using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    GameObject token;
    public Text clickCountTxt;
    public Button easyBtn;
    public Button mediumBtn;
    public Button hardBtn;
    MainToken tokenUp1 = null;
    MainToken tokenUp2 = null;
    List<int> faceIndexes =
        new List<int>{ 0, 1, 2, 3, 0, 1, 2, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11};
    public static System.Random rnd = new System.Random();
    private int shuffleNum = 0;
    float tokenScale = 4;
    float yStart = 2.5f;
    int numOfTokens = 8;
    float yChange = -5f;
    private int clickCount = 0;

    void StartGame()
    {
        int startTokenCount = numOfTokens;
        float xPosition = -6.2f;
        float yPosition = yStart;
        int row = 1;
        // The camera orthographicSize is 1/2 the height of the window
        float ortho = Camera.main.orthographicSize / 2.0f;
        for (int i = 1; i < startTokenCount + 1; i++)
        {
            shuffleNum = rnd.Next(0, (numOfTokens));
            var temp = Instantiate(token, new Vector3(
                xPosition, yPosition, 0),
                Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceIndexes[shuffleNum];
            temp.transform.localScale = 
                new Vector3(ortho / tokenScale, ortho / tokenScale, 0);
            faceIndexes.Remove(faceIndexes[shuffleNum]);
            numOfTokens--;
            xPosition = xPosition + 4;
            if (i % 4 < 1)
            {
                yPosition = yPosition + yChange;
                xPosition = -6.2f;
                row++;
            }
        }
        token.SetActive(false);
    }

    public void TokenDown(MainToken tempToken)
    {
        if (tokenUp1 == tempToken)
        {
            tokenUp1 = null;
        }
        else if (tokenUp2 == tempToken)
        {
            tokenUp2 = null;
        }
    }

    public bool TokenUp(MainToken tempToken)
    {
        bool flipCard = true;
        if (tokenUp1 == null)
        {
            tokenUp1 = tempToken;
        }
        else if (tokenUp2 == null)
        {
            tokenUp2 = tempToken;
        }
        else
        {
            flipCard = false;
        }
        return flipCard;
    }

    public void CheckTokens()
    {
        clickCount++;
        clickCountTxt.text = clickCount.ToString();
        if (tokenUp1 != null && tokenUp2 != null &&
            tokenUp1.faceIndex == tokenUp2.faceIndex)
        {
            tokenUp1.matched = true;
            tokenUp2.matched = true;
            tokenUp1 = null;
            tokenUp2 = null;
        }
    }

    public void HardSetup()
    {
        HideButtons();
        tokenScale = 12;
        yStart = 3.8f;
        numOfTokens = 24;
        yChange = -1.5f;
        StartGame();
    }

    public void MediumSetup()
    {
        HideButtons();
        tokenScale = 8;
        yStart = 3.4f;
        numOfTokens = 16;
        yChange = -2.2f;
        StartGame();
    }

    public void EasySetup()
    {
        HideButtons();
        StartGame();
    }

    private void HideButtons()
    {
        easyBtn.gameObject.SetActive(false);
        mediumBtn.gameObject.SetActive(false);
        hardBtn.gameObject.SetActive(false);
        GameObject[] startImages = 
            GameObject.FindGameObjectsWithTag("startImage");
        foreach (GameObject item in startImages)
            Destroy(item);
    }

    private void Awake()
    {
        token = GameObject.Find("Token");
    }

    void OnEnable()
    {
        easyBtn.onClick.AddListener(() => EasySetup());
        mediumBtn.onClick.AddListener(() => MediumSetup());
        hardBtn.onClick.AddListener(() => HardSetup());
    }
}
