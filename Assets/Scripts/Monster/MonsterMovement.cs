using UnityEngine;
using System.Collections;

public class MonsterPatrol : MonoBehaviour
{
    public Animator animator;
    public Transform[] patrolPoints;
    public float moveSpeed = 2.0f;
    public float turnTime = 1.0f; // Duration of the turn animation
    private int currentPointIndex;
    private bool isTurning;

    
    void Start()
    {
        if (patrolPoints.Length > 0)
        {
            float randomOffset = Random.Range(0.2f, 8.0f);
            Vector3 startPosition = patrolPoints[0].position;
            startPosition.x = patrolPoints[0].position.x + randomOffset;
            transform.position = startPosition;
            currentPointIndex = 1;
            StartCoroutine(Patrol());
        }
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            if (!isTurning && patrolPoints.Length > 0)
            {
                Transform targetPoint = patrolPoints[currentPointIndex];
                Vector3 direction = new Vector3(targetPoint.position.x - transform.position.x, 0, 0);
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
                //animator.SetFloat("Speed", moveSpeed);

                if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
                {
                    currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
                    StartCoroutine(TurnAround(-direction));
                }
            }
            yield return null;
        }
    }

    IEnumerator TurnAround(Vector3 turnDirection)
    {
        isTurning = true;

        // Determine the rotation angle based on turnDirection
        float targetAngle = Mathf.Atan2(turnDirection.x, turnDirection.z) * Mathf.Rad2Deg;

        // Smoothly rotate towards the target angle
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, targetAngle, 0);
        float elapsedTime = 0;

        while (elapsedTime < turnTime)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / turnTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;

        // Trigger the turn animation
        animator.SetTrigger("TurnTrigger");

        isTurning = false;
    }
}