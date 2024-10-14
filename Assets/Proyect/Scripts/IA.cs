using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : Character
{
    private GameObject[] balls;

    void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");

        if (balls.Length > 0)
        {
            Move(CalculateMovementDirection());
        }
    }

    private Vector3 CalculateMovementDirection()
    {
        GameObject closestBall = GetClosestBall();

        if (closestBall != null)
        {
            Vector3 ballPosition = closestBall.transform.position;
            Vector3 movementDirection;

            if (xAxis)
            {
                movementDirection = (ballPosition.x > transform.position.x) ? Vector3.right : Vector3.left;
            }
            else
            {
                movementDirection = (ballPosition.z > transform.position.z) ? Vector3.forward : Vector3.back;
            }

            return movementDirection;
        }
        return Vector3.zero;
    }

    private GameObject GetClosestBall()
    {
        GameObject closestBall = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject ball in balls)
        {
            float distance = Vector3.Distance(transform.position, ball.transform.position);

            if (distance < closestDistance)
            {
                closestBall = ball;
                closestDistance = distance;
            }
        }

        return closestBall;
    }
}
