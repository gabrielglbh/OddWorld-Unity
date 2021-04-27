using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Aplicado a los Breakables (Pots...)
public class BreakableController : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Ejecuta la animación de destrucción y limpia el objecto
    public void BreakObject() {
        animator.SetBool("smash", true);
        StartCoroutine(SetInactiveRoutine());
    }

    IEnumerator SetInactiveRoutine()
    {
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
    }
}
