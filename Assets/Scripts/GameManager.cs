using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int maxScore;
    public GameObject[] collectible;
    public GameObject player;
    public MovementController mc;
    public EnemyLogic el;
    public event Action transitionEvent;


    void Start()
    {
        collectible = GameObject.FindGameObjectsWithTag("Coin");
        player = GameObject.Find("Player");
        mc = player.GetComponent<MovementController>();
        maxScore = collectible.Length;
        mc.levelChange += ChangeLevel;
        CheckingMovementType();
    }

    void Update()
    {
        
    }

    public void ChangeLevel()
    {
        if (mc.score >= maxScore)
        {
            transitionEvent?.Invoke();
            Invoke(nameof(LoadNextLevel), 0.5f); 
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void CheckingMovementType()
    {

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 3)
        {
            mc.useFirstPersonMovement = true;
           
        }
        else
        {
            mc.useFirstPersonMovement = false;
        }
    }


}
