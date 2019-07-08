using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingAction : PlayActions
{
    public StringField displayText;
    public string word;
   

    int index;
    string showText;

    public override void Begin()
    {
        base.Begin();
        //uiBox.SetActive(true);
        SetUpWord();
    }

    public override bool IsRunning()
    {
        if (Input.inputString.Length > 0) TypeLetter(Input.inputString[0]);

        if (index >= word.Length)
        {
            runsOver++;
            if (runsOver == maxRuns)
            {
                return true;
            }
            else
            {
                SetUpWord();
            }
        }

        return false;

    }

    public override void Done()
    {
        base.Done();
       // uiBox.SetActive(false);
    }

    private void TypeLetter(char alphabet)
    {
        Debug.Log("Typing reached...");
        if (alphabet == word[index]) showText += "<color=green>" + word[index] + "</color>";
        else showText += "<color=red>" + word[index] + "</color>";
        index++;
        displayText.value = showText + word.Substring(index);
    }

    private void SetUpWord()
    {
        index = 0;
        showText = "";
        string newWord = dataDictionary.GetRandomWords();
        if (newWord == word)
        {
            SetUpWord();
            return;
        }
        else word = newWord;
        displayText.value = word;
    }

}
