using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{

    private Rigidbody2D npc;
    private Animator animator;
    // Dialog
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public float activationRadius = 4;
    public Transform player;

    public void SetAnimatorForMovingNPC()
    {
        npc = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("walking", true);
    }

    public void SetAnimatorForIdleNPC(Vector3 facingDirection)
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", facingDirection.x);
        animator.SetFloat("moveY", facingDirection.y);
    }

    public void AnimatedMove(Vector3 direction, Vector2 position)
    {
        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);
        npc.MovePosition(position);
    }

    // Cuando se para el NPC, se anima el idle state para que
    // siga al jugador
    public void AnimateToIdle(Vector2 facingPlayerDirection)
    {
        animator.SetBool("walking", false);
        animator.SetFloat("moveX", facingPlayerDirection.x);
        animator.SetFloat("moveY", facingPlayerDirection.y);
    }

    public void AnimateToMove()
    {
        animator.SetBool("walking", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogBox.SetActive(false);
        }
    }
}
