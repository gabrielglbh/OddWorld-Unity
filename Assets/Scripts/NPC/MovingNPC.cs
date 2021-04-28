using UnityEngine;
using System.Collections;

public class MovingNPC : NPCController
{
    // PatrolPoints
    private int currentPoint;
    public Transform[] path;
    public Transform currentGoal;
    public float speed;
    public Transform player;
    // Al tratar con floats se crea un margen de error al verificar las posiciones
    private float roundingDistance = 0.2f;
    private float activationRadius = 4;

    void Start()
    {
        GetComponent<NPCController>().SetAnimatorForMovingNPC();
    }

    void Update()
    {
        // Si la distancia entre el goal y la posición es mayor que el margen de error, moverse
        if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, speed * Time.deltaTime);
            Vector2 direction = temp - transform.position;
            direction = direction.normalized;
            GetComponent<NPCController>().AnimatedMove(direction, temp);
        }
        else
        {
            if (Vector3.Distance(player.position, transform.position) <= activationRadius)
            {
                currentGoal = transform;
                GetComponent<NPCController>().AnimateToIdle();
            }
            else
            {
                GetComponent<NPCController>().AnimateToMove();
                UpdateGoal();
            }
        }
    }

    private void UpdateGoal()
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
