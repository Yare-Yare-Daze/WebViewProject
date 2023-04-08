using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GoalChecker goalChecker;
    [SerializeField] private PenaltyKickBall penaltyKickBall;
    [SerializeField] private RectTransform goalPanel;
    [SerializeField] private float secondsToGoalRestart;
    [SerializeField] private float secondsToKickedRestart;

    private void Awake()
    {
        goalChecker.OnGoalScored += OnGoalHandler;
        penaltyKickBall.OnKicked += OnKickedHandler;
    }

    private void OnGoalHandler(int goalsInRow)
    {
        StartCoroutine(GoalRestartInSeconds(secondsToGoalRestart));
    }

    private void OnKickedHandler()
    {
        StartCoroutine(KickedRestartInSeconds(secondsToKickedRestart));
    }

    private IEnumerator GoalRestartInSeconds(float sec)
    {
        goalPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(sec);

        int goals = PlayerPrefs.GetInt("GoalsInRow");
        if (PlayerPrefs.GetInt("MaxGoals") < goals)
        {
            PlayerPrefs.SetInt("MaxGoals", goals);
        }

        SceneManager.LoadScene(0);
    }

    private IEnumerator KickedRestartInSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        int goals = PlayerPrefs.GetInt("GoalsInRow");
        if(PlayerPrefs.GetInt("MaxGoals") < goals)
        {
            PlayerPrefs.SetInt("MaxGoals", goals);
        }

        PlayerPrefs.SetInt("GoalsInRow", 0);

        SceneManager.LoadScene(0);
    }
}
