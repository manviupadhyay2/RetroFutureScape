using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level3_QuestionManager : MonoBehaviour
{
    public GameObject questionCanvas;
    public GameObject thirdPersonCanvas;
    public GameObject aimCanvas;
    public GameObject thirdPersonCam;
    public GameObject aimCam;
    public List<Level3_QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionTxt;

    private bool playerIsAnswering = false;
    private int currentQuestionIndex = -1;


    private void Start()
    {

        StartQuestionRound();
    }

    public void StartQuestionRound()
    {
        thirdPersonCanvas.SetActive(false);
        aimCanvas.SetActive(false);
        thirdPersonCam.SetActive(false);
        aimCam.SetActive(false);


        currentQuestionIndex++;
        if (currentQuestionIndex < QnA.Count)
        {
            QuestionTxt.text = QnA[currentQuestionIndex].Question;
            SetAnswers();
        }
        else
        {
            questionCanvas.SetActive(false);

            // Reset the cursor to locked and invisible
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


    public void StopQuestionRound()
    {

        // Deactivate the question canvas when the question round is over

        Debug.Log("StopQuestionRound called.");
        // Deactivate the question canvas when the question round is over
        questionCanvas.SetActive(false);

        // Activate the other canvases
        thirdPersonCanvas.SetActive(true);
        aimCanvas.SetActive(true);
        thirdPersonCam.SetActive(true);
        aimCam.SetActive(true);

        // Restore the original cursor state and visibility

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;



        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

    }

    public void correct()
    {
        // Stop the current question round
        Debug.Log("Correct method called.");
        StopQuestionRound();

    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Level3_AnswersScript>().isCorrect = false;

            // Update TMP text component
            TextMeshProUGUI optionText = options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            optionText.text = QnA[currentQuestionIndex].Answers[i];

            if (QnA[currentQuestionIndex].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<Level3_AnswersScript>().isCorrect = true;
            }
        }
    }
}
