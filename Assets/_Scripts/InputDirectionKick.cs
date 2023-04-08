using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDirectionKick : MonoBehaviour
{
    [SerializeField] private float timeToMaxForce;
    [SerializeField] private float maxImpactForce;

    private Touch touch;
    private Vector3 directionKick;
    private float touchHoldTime = 0f;
    private bool isIncreaseForce = true;
    private float impactForce;

    public Action<float> OnKick;

    public Vector3 DirectionKick
    {
        get { return directionKick; }
    }

    public float ImpactForce
    {
        get { return impactForce; }
    }

    public float ImpactForceNormalized
    {
        get { return impactForce / maxImpactForce; }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            // Increase impact force
            if(touch.phase == TouchPhase.Stationary)
            {
                if (isIncreaseForce && touchHoldTime >= timeToMaxForce)
                {
                    isIncreaseForce = false;
                }
                else if (!isIncreaseForce && touchHoldTime <= 0f) 
                {
                    isIncreaseForce = true;
                }

                if(isIncreaseForce)
                {
                    touchHoldTime += Time.deltaTime;
                    
                }
                else
                {
                    touchHoldTime -= Time.deltaTime;
                }
                
                float deltaFroceNormalized = touchHoldTime / timeToMaxForce;
                impactForce = deltaFroceNormalized * maxImpactForce;
                Debug.Log("impactForce: " + impactForce);
            }

            if(touch.phase == TouchPhase.Moved)
            {
                Vector3 touchMoveToViewport = Camera.main.ScreenToViewportPoint(touch.position);

                directionKick.y = touchMoveToViewport.y;

                if (touchMoveToViewport.x < 0.5f)
                {
                    directionKick.z = (touchMoveToViewport.x - 0.5f) / 0.5f;
                }
                else
                {
                    directionKick.z = (touchMoveToViewport.x - 0.5f) / 0.5f;
                }

                Debug.Log("Touch position: " + touchMoveToViewport);
            }
        }
    }

    public void OnClickKickButton()
    {
        OnKick?.Invoke(ImpactForce);
    }
}
