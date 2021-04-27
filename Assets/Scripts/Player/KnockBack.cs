using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Utilizado en los Hitbox del Player y los enemigos
// Se maneja el daño de la espada y el del enemigo
// Se maneja el KnockBack de golpear
public class KnockBack : MonoBehaviour
{

    // Fuerza con la que el objeto A aplica un empujón al objeto B
    public float thrust;
    // Tiempo que el objeto B está en staggered state o siendo empujado
    public float knockTime;
    // Daño al enemigo
    public float damage;

    // Si es un objeto que se puede romper Y es el jugador el que lo colisiona: Destruir objeto
    // Si other es un enemigo: Knockback aplicado y daño
    // Si other es el jugador: Daño aplicado por el enemigo al jugador
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Breakable") && this.gameObject.CompareTag("Hitbox")) {
            other.GetComponent<BreakableController>().BreakObject();
        } 
        // isTrigger para que no se ejecute este bloque 2 veces por los 2 Collider 2D que hay en el enemigo
        if (other.gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("Hitbox") && other.isTrigger)
        {
            Rigidbody2D objectBeingHit = other.GetComponent<Rigidbody2D>();
            if (objectBeingHit != null) 
            {
                // Dirección del vector hacia el que salir disparado
                Vector2 diff = objectBeingHit.transform.position - transform.position;
                diff = diff.normalized * thrust;
                objectBeingHit.AddForce(diff, ForceMode2D.Impulse);
                // Cambiar el estado del objeto y crear el knockback
                objectBeingHit.GetComponent<EnemyController>().state = EnemyState.staggered;
                other.GetComponent<EnemyController>().KnockBack(objectBeingHit, knockTime, damage);
            }
        } 
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Enemy") && other.isTrigger) 
        {
            other.GetComponent<PlayerController>().DealDamage(damage);
        }
    }
}
