using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyKickBall : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    [SerializeField] private Vector3 kickForce;
    [SerializeField] private InputDirectionKick inputDirectionKick;

    private float impactForce;

    private Rigidbody ballRB;

    public Vector3 KickForce
    {
        get { return kickForce; }
    }

    private void Awake()
    {
        ballRB = ballTransform.GetComponent<Rigidbody>();
        inputDirectionKick.OnKick += OnKickHandler;

        Debug.Log("kickForce before normalized: " + kickForce);
        kickForce = kickForce.normalized;
        Debug.Log("kickForce after normalized: " + kickForce);
    }

    private void Start()
    {

    }

    private void OnKickHandler(float impact)
    {
        kickForce *= impact;
        Debug.Log("kickForce after impactForce: " + kickForce);
        ballRB.AddForce(kickForce, ForceMode.Impulse);
    }
}
