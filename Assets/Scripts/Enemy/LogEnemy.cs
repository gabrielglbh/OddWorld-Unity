using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase única para los LogEnemies, hereda de EnemyControllers 
// en vez de MonoBehaviour directamente
public class LogEnemy : EnemyController
{

    private Rigidbody2D enemy;
    public Animator animator;
    // Posición del jugador a la que el enemigo se dirigirá
    public Transform target;
    public float activationRadius;
    public float attackRadius;

    void Start()
    {
        state = EnemyState.idle;
        enemy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        CheckDistanceForChase();
    }

    void CheckDistanceForChase() 
    {
        // Si la distancia entre el jugador y el enemigo es menor o igual que la distancia de activación
        // Y si es mayor que la distancia de ataque (para dejar un poco de margen)
        // El enemigo se moverá hacia el jugador
        if (Vector3.Distance(target.position, transform.position) <= activationRadius &&
            Vector3.Distance(target.position, transform.position) > attackRadius) 
        {
            if (state == EnemyState.idle || state == EnemyState.walk && state != EnemyState.staggered) 
            {
                // Dirección y movimiento en base al target y al speed del enemigo
                Vector3 movement = Vector3.MoveTowards(transform.position, target.position, Random.Range(3, 7) * Time.deltaTime);
                // Se cambia el estado a walk
                ChangeState(EnemyState.walk);
                // Se anima en función de la dirección que haya tomado el enemigo
                ChangeAnimatorPosition(movement - transform.position);
                animator.SetBool("wakeUp", true);
                // Se aplica el movimiento al enemigo
                enemy.MovePosition(movement);
            }
            // Si el jugador está fuera del radio de activación, se queda dormido
        } else if (Vector3.Distance(target.position, transform.position) > activationRadius) {
            animator.SetBool("wakeUp", false);
        }
    }

    private void ChangeAnimatorPosition(Vector2 direction) 
    {
        direction = direction.normalized;
        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);
    }

    private void ChangeState(EnemyState newState) 
    {
        if (state != newState) 
        {
            state = newState;
        }
    }
}
