using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goalsInRowText;
    [SerializeField] private TextMeshProUGUI maxGoalsText;
    [SerializeField] private GoalChecker goalChecker;

    private void Awake()
    {
        goalChecker.OnGoalScored += GoalTextUpdate;
    }

    private void GoalTextUpdate(int goalsInRow)
    {
        goalsInRowText.text = "Goals in a row: " + goalsInRow.ToString();
        if(goalsInRow > PlayerPrefs.GetInt("MaxGoals"))
        {
            maxGoalsText.text = "Max goals: " + goalsInRow;
        }
    }

    private void Start()
    {
        goalsInRowText.text = "Goals in a row: " + PlayerPrefs.GetInt("GoalsInRow");
        maxGoalsText.text = "Max goals: " + PlayerPrefs.GetInt("MaxGoals");
    }


}
