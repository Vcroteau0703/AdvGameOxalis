using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    [TextArea]
    public string[] sentences;
    TextMeshProUGUI text;
    public int index = 0;
    public float typingSpeed;
    public float startWait = 1f;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        NextSentence();
    }

    IEnumerator Type()
    {
        yield return new WaitForSecondsRealtime(startWait);
        startWait = 0f;
        string box = sentences[index];
        // types out each letter
        foreach (char letter in box.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed); // is not effected when pause game is active
        }
        yield return new WaitForSecondsRealtime(1f);
        text.text = "";
        index++;
        typingSpeed = 0.1f;
        if (index <= sentences.Length - 1)
        {
            NextSentence();
        }

    }

    public void NextSentence()
    {
        if (index <= sentences.Length - 1)
        {
            StartCoroutine(Type());
        }
        else
        {
            text.text = "";
        }

    }

}
