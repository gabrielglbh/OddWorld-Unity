using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Aplicado a los Breakables (Pots...)
public class BreakableController : MonoBehaviour
{
    public GameObject heart;
    private Animator animator;
    private int decideIfHeartAppears;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Ejecuta la animación de destrucción y limpia el objecto
    public void BreakObject()
    {
        animator.SetBool("smash", true);
        StartCoroutine(SetInactiveRoutine());
    }

    // Desactiva el objeto rompible y en base a decideIfHeartAppears
    // aparece o no un contenedor de corazón
    IEnumerator SetInactiveRoutine()
    {
        decideIfHeartAppears = UnityEngine.Random.Range(0, 3);
        yield return new WaitForSeconds(0.3f);
        animator.enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        if (decideIfHeartAppears == 0)
        {
            heart.SetActive(true);
        }
    }
}
