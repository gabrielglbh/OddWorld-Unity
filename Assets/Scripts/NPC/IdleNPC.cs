using UnityEngine;
using System.Collections;

public class IdleNPC : NPCController
{
    public Vector3 facingDirection;
    private Vector3[] directions = new Vector3[]
    {
        new Vector3(1, 0, 0),
        new Vector3(-1, 0, 0),
        new Vector3(0, 1, 0),
        new Vector3(0, -1, 0),
    };
    // Con el objeto serialiazado, permite su cambio en runtime afectando a toda la clase
    // al igual que el RuntimeValue de los ScriptableObjects
    [SerializeField]
    private bool npcRoutine = true;

    void Start()
    {
        SetAnimatorForIdleNPC(facingDirection);
        StartCoroutine(MoveStationary());
    }

    void Update()
    {
        // Determina si el jugador está dentro de su area y "le mira"
        if (Vector3.Distance(player.position, transform.position) <= activationRadius)
        {
            npcRoutine = false;
            Vector3 temp = Vector3.MoveTowards(transform.position, player.position, 1 * Time.deltaTime);
            Vector2 direction = temp - transform.position;
            AnimateToIdle(direction.normalized);
        }
        else
        {
            if (!npcRoutine)
            {
                StartCoroutine(MoveStationary());
            }
            npcRoutine = true;
        }
    }

    private IEnumerator MoveStationary()
    {
        while (true)
        {
            AnimateToIdle(directions[Random.Range(0, directions.Length)]);
            yield return new WaitForSeconds(3f);
            if (!npcRoutine) yield break;
        }
    }
}
