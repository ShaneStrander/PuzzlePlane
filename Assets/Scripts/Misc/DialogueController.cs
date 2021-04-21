using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : BlueOrb
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI continueText;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    private bool canContinue = false;
    public bool loopSentences = false;
    public int numberOfSentencesToLoop;
    private bool startLooping = false;

    // Defining enums
    private enum DialogueState { Inactive, Active, Completed }
    private DialogueState state = DialogueState.Inactive;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            canContinue = true;
        }
    }

    public void PressE()
    {
        if (Time.time > buttonStartTime + buttonDelay)
        {
            buttonStartTime = Time.time;
            if (state == DialogueState.Inactive)
            {
                // open box and start typing
                OpenDialogueBox();
            }
            else if (state == DialogueState.Active)
            {
                // continue dialogue
                if (canContinue)
                {
                    //if (index == sentences.Length - 1)
                    //{
                    //    state = DialogueState.Completed;
                    //    continueText.text = "Press \"E\" to close...";
                    //}
                    //else
                    //{
                        NextSentence();
                    //}
                }
            }
            else if (state == DialogueState.Completed)
            {
                // close box and reset
                if (canContinue)
                {
                    CloseDialogueBox();
                }
            }
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        canContinue = false;
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

            if (index == sentences.Length - 1)
            {
                state = DialogueState.Completed;
                continueText.text = "Pres \"E\" to close...";
            }
        }
    }

    public new void OpenDialogueBox()
    {
        boxIsOpen = true;
        StartCoroutine(BoxOpen());
        state = DialogueState.Active;
        if (startLooping && index == sentences.Length - numberOfSentencesToLoop - 1)
        {
            NextSentence();
        }
        else
        {
            StartCoroutine(Type());
        }
    }

    public new void CloseDialogueBox()
    {
        StopAllCoroutines();
        boxIsOpen = false;
        canContinue = false;
        state = DialogueState.Inactive;
        StartCoroutine(BoxClose());
        textDisplay.text = "";

        if (loopSentences)
        {
            // If we finished all dialogue at least once, begin from looping index
            if (index == sentences.Length - 1 || startLooping == true)
            {
                index = sentences.Length - numberOfSentencesToLoop - 1;
                startLooping = true;
            }
            // Else, just leave the index as was and we'll continue from where we left off
            // can change to "index = 0" to reset
        }
        else
        {
            index = 0;
            continueText.text = "Press \"E\" to continue...";
        }
    }

    public void SetDialogue(string[] newSentences, int loopVar)
    {
        sentences = newSentences;
        index = 0;
        canContinue = false;
        numberOfSentencesToLoop = loopVar;
        startLooping = false;
    }
}
