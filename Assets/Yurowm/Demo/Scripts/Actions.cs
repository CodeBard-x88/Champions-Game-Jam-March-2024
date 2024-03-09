using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class Actions : MonoBehaviour {

	private Animator animator;

	const int countOfDamageAnimations = 3;
	int lastDamageAnimation = -1;

    void Start()
    {
        animator = GetComponent<Animator> ();
    }


    void Update()
    {
		if (animator != null) {

			if (Input.GetKeyDown(KeyCode.O)) {

				animator.SetTrigger("Run");

			}

		}
    }

    public void Stay () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 0f);
		}

	public void Walk () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 0.5f);
	}

	public void Run () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 1f);
	}

	public void Fire () {

		animator.SetTrigger ("Fire");
	}

	public void Reload() {

		animator.SetTrigger("Reload");
	}

	
	
}
