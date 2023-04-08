using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyKickBall : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    [SerializeField] private InputDirectionKick inputDirectionKick;
    [SerializeField] private PlayerMoveToBall playerMoveToBall;
    [SerializeField] private Vector3 kickForce;
    [SerializeField] private Vector3 kickForceTest;

    private bool needUpdateForceDir = true;
    private Rigidbody ballRB;

    public Action OnKicked;

    public Vector3 KickForce
    {
        get { return kickForce; }
    }

    private void Awake()
    {
        ballRB = ballTransform.GetComponent<Rigidbody>();
        inputDirectionKick.OnKick += OnKickHandler;
        playerMoveToBall.OnPlayerKicked += OnPlayerKickedHandler;
        kickForce = kickForce.normalized;
    }

    private void Update()
    {
        // Allready normalized
        if(needUpdateForceDir)
        {
            kickForce.y = inputDirectionKick.DirectionKick.y;
            kickForce.z = inputDirectionKick.DirectionKick.z;
        }
    }

    private void OnKickHandler(float impact, Vector3 dir)
    {
        needUpdateForceDir = false;
        kickForce.y = dir.y;
        kickForce.z = dir.z;
        kickForce *= impact;
    }

    private void OnPlayerKickedHandler()
    {
        ballRB.AddForce(kickForce, ForceMode.Impulse);
        OnKicked?.Invoke();
        Debug.Log("kickForce on handler: " + kickForce);
    }
}
