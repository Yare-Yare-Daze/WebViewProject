using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyKickBall : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    [SerializeField] private InputDirectionKick inputDirectionKick;

    private Vector3 kickForce;
    private Rigidbody ballRB;

    public Vector3 KickForce
    {
        get { return kickForce; }
    }

    private void Awake()
    {
        ballRB = ballTransform.GetComponent<Rigidbody>();
        inputDirectionKick.OnKick += OnKickHandler;
        kickForce = kickForce.normalized;
    }

    private void Update()
    {
        // Allready normalized
        kickForce.y = inputDirectionKick.DirectionKick.y;
        kickForce.z = inputDirectionKick.DirectionKick.z;
    }

    private void OnKickHandler(float impact)
    {
        kickForce *= impact;
        Debug.Log("kickForce after impactForce: " + kickForce);
        ballRB.AddForce(kickForce, ForceMode.Impulse);
    }
}
