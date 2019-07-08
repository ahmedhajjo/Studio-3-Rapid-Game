using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MCQAction : PlayActions
{

    public StringField text;
    int answer;
    bool wrongPressed;

    bool isCorrect;
    public override void Begin()
    {
        base.Begin();
        Cursor.visible = true;
        SetQuestion();
    }

    public override bool IsRunning()
    {
        if (runsOver == maxRuns)
            return true;
        return false;
    }

    public override void Done()
    {
        base.Done();
        //uiBox.SetActive(false);
    }

    private void SetQuestion()
    {
        //questionText.color = Color.white;
        ClickQuestions newQuestion = dataDictionary.GetClickQuestion();

        while (newQuestion.question == text.value)
        {
            newQuestion = dataDictionary.GetClickQuestion();
        }

        text.value = newQuestion.question;
        answer = newQuestion.buttonID;
    }

    public void CheckAnswer(int buttonID)
    {
        if (!wrongPressed)
        {
            if (buttonID == answer)
            {
                if (runsOver != maxRuns) SetQuestion();
            }

            else if (buttonID != answer)
            {
                wrongPressed = true;
                //questionText.color = Color.red;
                StartCoroutine("NextQuestion");
            }
        }
    }

    IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(1f);
        SetQuestion();
        runsOver++;
        wrongPressed = false;
    }

}
