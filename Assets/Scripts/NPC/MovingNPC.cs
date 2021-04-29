using UnityEngine;
using System.Collections;

public class MovingNPC : NPCController
{
    // PatrolPoints
    private int currentPoint;
    public Transform[] path;
    public Transform currentGoal;
    public float speed;
    // Al tratar con floats se crea un margen de error al verificar las posiciones
    private float roundingDistance = 0.2f;

    void Start()
    {
        SetAnimatorForMovingNPC();
    }

    void Update()
    {
        // Si la distancia entre el goal y la posición es mayor que el margen de error, moverse
        if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, speed * Time.deltaTime);
            Vector2 direction = temp - transform.position;
            direction = direction.normalized;
            AnimatedMove(direction, temp);
        }
        else
        {
            if (Vector3.Distance(player.position, transform.position) <= activationRadius)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                Vector2 direction = temp - transform.position;
                currentGoal = transform;
                AnimateToIdle(direction.normalized);

            }
            else
            {
                AnimateToMove();
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
