using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] TextMeshProUGUI volumeNumberText;
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] TextMeshProUGUI sensitivityNumberText;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        volumeNumberText.text = $"{Mathf.Round(volumeSlider.value * 10) / 10}";
        sensitivitySlider.value = PlayerPrefs.GetFloat("MouseS");
        sensitivityNumberText.text = $"{Mathf.Round(sensitivitySlider.value * 10) / 10}";
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Volume(Slider slider)
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
        volumeNumberText.text = $"{Mathf.Round(slider.value * 10) / 10}";

    }
    public void MouseSens(Slider slider)
    {
        PlayerPrefs.SetFloat("MouseS", slider.value);
        sensitivityNumberText.text = $"{Mathf.Round(slider.value * 10) / 10}";
    }
}
