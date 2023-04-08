using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyKickBall : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    [SerializeField] private Vector3 kickForce;
    [SerializeField] private float impactForce;

    private Rigidbody ballRB;

    private void Awake()
    {
        ballRB = ballTransform.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Debug.Log("kickForce before normalized: " + kickForce);
        kickForce = kickForce.normalized;
        Debug.Log("kickForce after normalized: " + kickForce);
        kickForce *= impactForce;
        Debug.Log("kickForce after impactForce: " + kickForce);
        ballRB.AddForce(kickForce, ForceMode.Impulse);
    }
}
