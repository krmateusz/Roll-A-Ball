using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextHandler : MonoBehaviour
{
    public GameObject player;
    public MovementController mc;
    public TMP_Text scoreText;
    public GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        mc = GameObject.Find("Player").GetComponent<MovementController>();
        mc.pickupEvent += UpdateScoreText;
    }


    void Update()
    {
        
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + mc.score + "/" + gm.maxScore;
    }
}
