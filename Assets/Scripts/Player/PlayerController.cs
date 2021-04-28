using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState {
    walk, 
    attack,
    idle
}

// Clase única para el jugador
public class PlayerController : MonoBehaviour
{

    public float speed;
    public PlayerState state;
    public InputDirection input;

    public FloatValue currentHealth;
    public CustomSignal playerHealthSignal;

    public BoolValue gameOver;
    public CustomSignal gameOverSignal;

    public FloatValue currentPoints;
    public Text points;

    private Vector3 change;
    private Rigidbody2D player;
    private Animator animator;

    void Start()
    {
        state = PlayerState.walk;
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", 1);
        player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        change = Vector3.zero;
        // Recibe de InputController la dirección a la que mover el jugador
        change.x = input.RuntimeValue.x;
        change.y = input.RuntimeValue.y;

        if (state == PlayerState.walk || state == PlayerState.idle) {
            UpdateAnimationStateAndMove();
        }
    }

    // A la espera de ser ejecutado mediante la notificación de isAttackSignal
    // llamada desde ButtonInputController
    public void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    // Rutina que crea el ataque con sus hitboxes
    private IEnumerator AttackRoutine() {
        animator.SetBool("attacking", true);
        state = PlayerState.attack;
        yield return null; // Esperamos un frame
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.3f);
        state = PlayerState.walk;
    }

    // Crea las animaciones al moverse y mueve al jugador
    // No es necesario actualizar el estado porque ya se entra con la condición sobre ellos
    void UpdateAnimationStateAndMove() {
        if (change != Vector3.zero) {
            // Para evitar la aceleración en diagonal
            change.Normalize();
            player.MovePosition(transform.position + change * speed * Time.deltaTime);

            // Anima los sprites del jugador mediante los parámetros definidos en el Animator
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        } else {
            animator.SetBool("moving", false);
        }
    }

    // Calcula el daño en el enemigo sobre el jugador
    // Llamado en KnockBack.cs
    public void DealDamage(float damage) 
    {
        currentHealth.RuntimeValue -= damage;
        if (currentHealth.RuntimeValue >= 0) 
        {
            // Notificar a los listeners que la vida del jugador ha cambiado
            playerHealthSignal.Notify();
            if (currentHealth.RuntimeValue == 0) 
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        gameOver.RuntimeValue = true;
        gameOverSignal.Notify();
        this.gameObject.SetActive(false);
    }

    // Llamado al notificarse EnemyDefeatedSignal desde EnemyController al morir un enemigo,
    // que actualiza la puntuación del jugador
    public void UpdatePoints() 
    {
        currentPoints.RuntimeValue += 1;
        string p = currentPoints.RuntimeValue.ToString();
        if (p.Length == 1) 
        {
            p = "00" + p;
        }
        else if (p.Length == 2) 
        {
            p = "0" + p;
        }
        points.text = p;
    }
}
