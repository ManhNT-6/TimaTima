using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Game1 : MonoBehaviour
{
    [SerializeField] private Button select1;
    [SerializeField] private Button select2;
    [SerializeField] private Button select3;
    
    private int key;
    private int level = 1;
    private bool isCorrect;
    [SerializeField] private List<Sprite> sprites;    // sprite to display on button for player choose 
    [SerializeField] private List<AudioClip> audioClips;     // audioClip on this level
    [SerializeField] AudioSource audioSource;
    
    public UnityEvent OnCorrect;
    public UnityEvent OnWrong;
    public UnityEvent OnChangeGame;
    
    private void Awake()
    {
        InitLevel1();
    }

    void InitLevel1()
    {
        key = 1;
        level = 1;
        select1.image.sprite = sprites[0];
        select2.image.sprite = sprites[1];
        select3.image.sprite = sprites[2];
        audioSource.clip = audioClips[0];
    }

    public void NextLevel()
    {
        if (level == 1) InitLevel2();
        else if (level == 2) InitLevel3();
        else if (level == 3) ChangeGame2();
    }
    
    void InitLevel2()
    {
        key = 3;
        level = 2;
        select1.image.sprite = sprites[0];
        select2.image.sprite = sprites[2];
        select3.image.sprite = sprites[3];
        audioSource.clip = audioClips[1];
    }

    void InitLevel3()
    {
        key = 2;
        level = 3;
        select1.image.sprite = sprites[0];
        select2.image.sprite = sprites[2];
        select3.image.sprite = sprites[3];
        audioSource.clip = audioClips[1];
    }

    public void CheckAnswer(int no)
    {   
        isCorrect = no == key ? true : false;
        if (isCorrect) OnCorrect.Invoke();
        else OnWrong.Invoke();
    }

    void ChangeGame2()
    {
        var mainMenu = FindObjectOfType<MainMenuCanvasManager>();
        mainMenu.GoToOtherPageWithHisIndex(6);
    }
    
    public void PlaySound()
    {
        audioSource.Play();
    }
    
}
