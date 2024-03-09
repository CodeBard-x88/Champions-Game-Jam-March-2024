using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayRunAnimation()
    {
        animator.SetTrigger("Run");
    }

    public void PlayReloadAnimation()
    {
        animator.SetTrigger("Reload");
    }

    public void PlayFireAnimation()
    {
        animator.SetTrigger("Fire");
    }

    public void PlayStandAnimation() {

        animator.SetTrigger("Stand");
    }
}
