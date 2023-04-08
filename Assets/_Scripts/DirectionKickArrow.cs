using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionKickArrow : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private PenaltyKickBall penaltyKickBall;


    private void Update()
    {
        Vector3 targetVector = lineRenderer.GetPosition(1);

        targetVector = penaltyKickBall.KickForce;

        lineRenderer.SetPosition(1, targetVector);

        //Debug.Log("linePosition(1): " + lineRenderer.GetPosition(1));
    }
}
