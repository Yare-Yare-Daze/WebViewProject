using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDirectionKick : MonoBehaviour
{
    [SerializeField] private float timeToMaxForce;
    [SerializeField] private float maxImpactForce;
    //[SerializeField] private float speedChangeForce;

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

    private void Update()
    {
        if(Input.touchCount > 0)
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


                Debug.Log("Touch position: " + touchMoveToViewport);
            }
        }
    }

    public void OnClickKickButton()
    {
        OnKick?.Invoke(ImpactForce);
    }
}
