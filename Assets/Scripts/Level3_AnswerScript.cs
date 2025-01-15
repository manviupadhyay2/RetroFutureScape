using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_AnswersScript : MonoBehaviour
{
    public bool isCorrect = false;
    public Level3_QuestionManager quizManager;

    void Awake()
    {
        // Move the FindObjectOfType call here
        quizManager = FindObjectOfType<Level3_QuestionManager>();
    }

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.correct();
        }

        quizManager.questionCanvas.SetActive(false);

        Time.timeScale = 1f;

        quizManager.StartQuestionRound();

    }
}