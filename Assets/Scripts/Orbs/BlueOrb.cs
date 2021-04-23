using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueOrb : UseOrbs
{
    // Inspector Fields
    [SerializeField] private string dialogueText;

    // General Fields
    private RectTransform dialogueTextBox;
    private Animator dialogueBoxAnimator;

    protected float buttonDelay = 0.1f;
    protected float buttonStartTime;

    // Public fields
    public bool boxIsOpen;

    private new void Awake()
    {
        base.Awake();
        dialogueTextBox = transform.Find("Canvas").Find("Panel").GetComponent<RectTransform>();
        dialogueBoxAnimator = dialogueTextBox.GetComponent<Animator>();
        boxIsOpen = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Open Dialogue Box
    public void OpenDialogueBox()
    {
        if (Time.time > buttonStartTime + buttonDelay)
        {
            buttonStartTime = Time.time;
            boxIsOpen = true;
            StartCoroutine(BoxOpen());
        }
    }

    protected IEnumerator BoxOpen()
    {
        dialogueBoxAnimator.SetTrigger("start");
        dialogueBoxAnimator.SetBool("close", false);
        yield return new WaitUntil(() => dialogueTextBox.localScale.x == 1);
    }

    // Fade's the text out
    public void CloseDialogueBox()
    {
        if (Time.time > buttonStartTime + buttonDelay)
        {
            buttonStartTime = Time.time;
            boxIsOpen = false;
            StartCoroutine(BoxClose());
        }
    }

    protected IEnumerator BoxClose()
    {
        dialogueBoxAnimator.SetBool("close", true);
        yield return new WaitUntil(() => dialogueTextBox.localScale.x == 0);
    }
}
