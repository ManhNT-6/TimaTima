using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game1 : MonoBehaviour
{
    [SerializeField] private Button select1;
    [SerializeField] private Button select2;
    [SerializeField] private Button select3;
    
    private int key;
    private int level = 1;
    [SerializeField] private List<Sprite> sprites;    // sprite to display on button for player choose 
    [SerializeField] private List<AudioClip> audioClips;     // audioClip on this level
    private AudioSource audioSource;

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
    }

    public void InitLevel2()
    {
        key = 3;
        level = 2;
        select1.image.sprite = sprites[0];
        select2.image.sprite = sprites[2];
        select3.image.sprite = sprites[3];
    }

    public void CheckAnswer(int no)
    {   
        if (no == key) Debug.Log("Correct");
        else Debug.Log("Wrong");
    }
    
    public void PlaySound()
    {
        audioSource.clip = audioClips[level-1];
        audioSource.Play();
    }
    
    
    
}
