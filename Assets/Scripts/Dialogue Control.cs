using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;
    private bool finished;

    [HideInInspector]
    public bool isSpeaking;



    public void Speech(Sprite p, string[] txt, string actorName)
    {
        if (isSpeaking) return;  // <-- impede chamar de novo enquanto fala

        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        isSpeaking = true;

        StartCoroutine(TypeSentence());
    }
    IEnumerator TypeSentence()
    {
        finished = false;          // marca que ainda está digitando
        speechText.text = "";      // limpa o texto ANTES de começar

        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        finished = true;           // terminou de digitar
    }

    public void NextSentence()
    {
        if (finished)  // só avança quando terminar de digitar
        {
            if (index < sentences.Length - 1)
            {
                index++;
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                isSpeaking = false;  // <-- libera o NPC para novo diálogo
            }

        }
    }
}