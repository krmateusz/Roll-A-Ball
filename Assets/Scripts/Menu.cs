using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioSource audiosource;
    public GameObject mainMenuPanel, optionsPanel;
    public Slider volumeSlider;


    private void Start()
    {
        audiosource = GameObject.Find("blip").GetComponent<AudioSource>();
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        AudioListener.volume = savedVolume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
        audiosource.Play();
    }
    public void GameOptions()
    {
        audiosource.Play();
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
    public void HideOptions()
    {
        audiosource.Play();
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        audiosource.Play();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }
}