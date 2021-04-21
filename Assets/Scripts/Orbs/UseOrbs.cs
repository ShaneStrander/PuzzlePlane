using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseOrbs : MonoBehaviour
{
    // Inspector Fields
    [SerializeField] private string popUpText;

    // General Fields
    protected Text textBox;
    private Animator textBoxAnimator;

    protected void Awake()
    {
        textBox = transform.Find("Canvas").Find("Text").GetComponent<Text>();
        textBoxAnimator = textBox.GetComponent<Animator>();
        textBox.text = popUpText;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fade's the text in
    public void TextFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        textBoxAnimator.SetTrigger("start");
        textBoxAnimator.SetBool("fade", false);
        yield return new WaitUntil(() => textBox.color.a == 1);
    }

    // Fade's the text out
    public void TextFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        textBoxAnimator.SetBool("fade", true);
        yield return new WaitUntil(() => textBox.color.a == 0);
    }
}
