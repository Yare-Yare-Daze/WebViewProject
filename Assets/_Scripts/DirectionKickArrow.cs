using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionKickArrow : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private PenaltyKickBall penaltyKickBall;
    [SerializeField] private InputDirectionKick inputDirectionKick;
    [SerializeField] private Renderer arrowMaterial;

    private void Awake()
    {
        inputDirectionKick.OnKick += OnKickHandler;
    }

    private void OnKickHandler(float impact, Vector3 dir)
    {
        lineRenderer.enabled = false;
    }

    private void Update()
    {

        lineRenderer.SetPosition(1, penaltyKickBall.KickForce);

        arrowMaterial.material.color = Color.Lerp(Color.white, Color.green, inputDirectionKick.ImpactForceNormalized);
    }
}
