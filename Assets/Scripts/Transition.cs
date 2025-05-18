using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Transition : MonoBehaviour
{

    public GameManager gm;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (gm == null)
        {
            gm = GameObject.Find("GameManager")?.GetComponent<GameManager>();

            if (gm != null)
            {
                gm.transitionEvent += AnimationTransition;
            }
        }
    }

    public void AnimationTransition()
    {
        animator.SetTrigger("AnimationStart");
    }
}
