using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class AnswerManager : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public int strikes = 0;
    public void Answer()
    {
        if (!isCorrect)
        {
            strikes++;
            quizManager.correct();
        }
        else
        {
            quizManager.correct();
        }

    }
}
