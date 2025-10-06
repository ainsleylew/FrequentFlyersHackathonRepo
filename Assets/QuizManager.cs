using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> questions;
    public GameObject[] options;
    public int currentQuestion = 0;
    public Text questionText;

    //amount of wrong answers, level should fail if >=3
    private int strikes = 0;

    // Flag to prevent rapid-fire updates (fixes double-text glitch)
    private bool isUpdating = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newQuestion();
    }
    
    public void correct()
    {
        newQuestion();
    }
    
    public void newQuestion()
    {
        // Prevent rapid calls (e.g., from mashing buttons)
        if (isUpdating) return;
        
        // Check if we've run out of questions
        if (currentQuestion >= questions.Count)
        {
            // Quiz over: Log strikes, show end screen, or whatever you want
            Debug.Log("Quiz complete! Strikes: " + strikes);
            // Optional: Disable buttons or load a win/lose scene
            // foreach (GameObject opt in options) { opt.SetActive(false); }
            return;
        }

        isUpdating = true; // Lock it during update

        //assign the current question
        questionText.text = questions[currentQuestion].Question;
        
        for (int i = 0; i < options.Length; ++i)
        {
            // Safety: Skip if not enough answers defined
            if (i >= questions[currentQuestion].Answers.Length) continue;
            
            options[i].GetComponent<AnswerManager>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = questions[currentQuestion].Answers[i];

            // Set correct ones (fixed logic: check if i matches any correct index)
            for (int j = 0; j < questions[currentQuestion].correctAnswers.Length; ++j)
            {
                if (questions[currentQuestion].correctAnswers[j] == i)
                {
                    options[i].GetComponent<AnswerManager>().isCorrect = true;
                    break; // No need to check further
                }
            }
        }
        
        currentQuestion++;
        isUpdating = false; // Unlock
    }
}
