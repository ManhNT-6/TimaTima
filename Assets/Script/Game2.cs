using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Game2 : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] private TMP_InputField answerInput;
    public List<string> listAnswer = new List<string>();
    
    private int level;
    private bool isCorrect;
    
    public UnityEvent OnCorrect;
    public UnityEvent OnWrong;
     
    public void CheckAnswer()
    {
        var answer = answerInput.text;
        if (answer == listAnswer[level])
        {
            isCorrect = true;
            OnCorrect.Invoke();
        }
        else OnWrong.Invoke();
    }

    public void NextLevel()
    {
        level++;
    }
    
    
}
