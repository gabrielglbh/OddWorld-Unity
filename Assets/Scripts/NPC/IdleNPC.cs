using UnityEngine;
using System.Collections;

public class IdleNPC : NPCController
{
    public Vector3 facingDirection;

    void Start()
    {
        SetAnimatorForIdleNPC(facingDirection);
    }
}
