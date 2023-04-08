using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{
    public Action<int> OnGoalScored;
    private int goalsInRow;

    private void Awake()
    {
        goalsInRow = PlayerPrefs.GetInt("GoalsInRow");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            goalsInRow++;
            PlayerPrefs.SetInt("GoalsInRow", goalsInRow);
            Debug.Log("Goal scored!");
            OnGoalScored?.Invoke(goalsInRow);
        }
    }
}
