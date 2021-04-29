using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    idle,
    walk,
    attack,
    staggered
}

// Clase genérica para todos los enemigos
// Cada enemigo de cada tipo, tendrá su propio script 
// y herederá de aquí los datos expuestos 
public class EnemyController : MonoBehaviour
{
    public EnemyState state;
    // ScriptableObject ajeno a las escenas y reusable
    public FloatValue maxHealth;
    public FloatValue currentEnemies;
    public CustomSignal enemyDefeteadSignal;
    public float health;
    public string id;
    public int attack;

    void Awake() {
        health = maxHealth.initialValue;
    }

    // Calcula el daño en el enemigo cuando se ejecuta el KnockBack
    // Si la vida del enemigo es 0 o menos, hacemos desaparecer el enemigo
    // y notifica a SpawnController
    private void CalculateDamageDealt(float damage) 
    {
        health -= damage;
        if (health <= 0) 
        {
            currentEnemies.RuntimeValue -= 1;
            Destroy(this.gameObject);
            enemyDefeteadSignal.Notify();
        }
    }

    /**
    * Funciones utilizadas por otras clases
    *   - KnockBack.cs: cuando el jugador es empujado por el enemigo
    */
    public void KnockBack(Rigidbody2D obj, float time, float damage) 
    {
        StartCoroutine(StopKnockBackRoutine(obj, time));
        CalculateDamageDealt(damage);
    }

    // Define en base a time el tiempo que debe viajar hacia atrás
    // el enemigo. Después se para y vuelve a su estado normal.
    private IEnumerator StopKnockBackRoutine(Rigidbody2D obj, float time) 
    {
        if (obj != null) 
        {
            yield return new WaitForSeconds(time);
            obj.velocity = Vector2.zero;
            state = EnemyState.idle;
        }
    }
}