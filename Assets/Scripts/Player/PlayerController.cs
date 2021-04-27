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
    private Rigidbody2D player;
    private Vector3 change;
    // Controlador para lanzar las animaciones del jugador
    // dependendiendo de state
    private Animator animator;
    public FloatValue currentHealth;
    public BoolValue gameOver;
    public CustomSignal playerHealthSignal;
    public CustomSignal gameOverSignal;
    // Varianles usadas para la puntación
    public FloatValue currentPoints;
    public Text points;

    void Start()
    {
        state = PlayerState.walk;
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 1);
        animator.SetFloat("moveY", 0);
        player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Reset del movimiento cada frame
        change = Vector3.zero;
        // Directamente recoje si se pulsa WASD o no
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        // Solo se ataca si se pulsa la tecla E
        if (Input.GetButtonDown("attack")) {
            StartCoroutine(AttackRoutine());
        }
        // Si no se pulsa la tecla de atacar... moverse y animar el movimiento
        else if (state == PlayerState.walk || state == PlayerState.idle) {
            UpdateAnimationStateAndMove();
        }
    }

    // Rutina que crea el ataque - con sus hitboxes y todo
    // "attacking" ejecuta la animación de atacar
    private IEnumerator AttackRoutine() {
        animator.SetBool("attacking", true);
        state = PlayerState.attack;
        yield return null; // Esperamos un frame
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.3f);
        // Reset del estado para poder realizar un nuevo ataque
        state = PlayerState.walk;
    }

    // Crea las animaciones al moverse y mueve al jugador
    // No es necesario actualizar el estado porque ya se entra con la condición sobre ellos
    void UpdateAnimationStateAndMove() {
        if (change != Vector3.zero) {
            // Para evitar la aceleración en diagonal
            change.Normalize();
            player.MovePosition(transform.position + change * speed * Time.deltaTime);
            // Anima los sprites del jugador mediante los parámetros
            // definidos en el Animator, por lo que si sabe que moveX o moveY
            // tiene un valor, ejecutará la animación asociada a su valor
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
                gameOver.RuntimeValue = true;
                gameOverSignal.Notify();
                this.gameObject.SetActive(false);
            }
        }
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
