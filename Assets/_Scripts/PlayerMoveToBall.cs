using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveToBall : MonoBehaviour
{
    [SerializeField] private InputDirectionKick inputDirectionKick;
    [SerializeField] private Transform ballTransform;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;

    public Action OnPlayerKicked;

    private bool isKicked = false;

    private void Awake()
    {
        inputDirectionKick.OnKick += OnKickHandler;
    }

    private void OnKickHandler(float impact, Vector3 dir)
    {
        animator.SetBool("isNeedKick", true);
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        float playerX = transform.position.x;
        float playerZ = transform.position.z;

        while(!isKicked)
        {
            playerX = Mathf.Lerp(playerX, ballTransform.position.x, speed * Time.deltaTime);
            playerZ = Mathf.Lerp(playerZ, ballTransform.position.z, speed * Time.deltaTime);
            //transform.position = Vector3.Lerp(transform.position, ballTransform.position, speed * Time.deltaTime);
            transform.position = new Vector3(playerX, transform.position.y, playerZ);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        { 
            OnPlayerKicked?.Invoke();
            isKicked = true;
        }
    }
}
