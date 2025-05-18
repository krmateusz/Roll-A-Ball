using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeManagment : MonoBehaviour
{
    private float Timer = 0f;
    public TMP_Text timerText;
    public GameObject informationText;
    int seconds;
    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Q)) 
        {
            Time.timeScale = 1;
            informationText.SetActive(false);
        }
        if (Time.timeScale == 1)
        {
            Timer += Time.deltaTime; 
            seconds = Mathf.FloorToInt(Timer % 60);
            timerText.text = string.Format("{00}", seconds);

            if (Timer >= 25f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
