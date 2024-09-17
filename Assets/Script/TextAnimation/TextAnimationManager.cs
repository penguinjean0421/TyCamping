using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextAnimationManager : MonoBehaviour
{
    [SerializeField] private TextAnimationAsset dialogAsset;
    [SerializeField] private SpeechBubble speechBubble;
    public Dictionary<int, UnityAction> actionDictionary = new Dictionary<int, UnityAction>();

    [SerializeField] private int currentIndex;

    [SerializeField] private List<KeyCode> keyList;

    private bool isEnd = false;
    public UnityEvent endEvent;

    public void ShowDialog(int index)
    {
        var data = dialogAsset.speechBubbles[index];
        //speechBubble.SetSprite(data.sprite);
        if (actionDictionary.TryGetValue(index, out var value))
        {
            value.Invoke();
        }
        speechBubble.SetPosition(transform.position = data.position);
        speechBubble.SetSize(data.size);
        speechBubble.Print(dialogAsset.phrases[index]);
    }

    public virtual void Initialize()
    {

    }

    public void Skip()
    {
        speechBubble.Skip();
    }

    void Start()
    {
        actionDictionary = new Dictionary<int, UnityAction>();
        Initialize();
        currentIndex = 0;
        ShowDialog(currentIndex);
    }

    void Update()
    {
        if (CheckKeyDown() && !speechBubble.IsPrinting() && currentIndex < dialogAsset.phrases.Count-1)
        {
            currentIndex++;
            ShowDialog(currentIndex);
        }
        else if (CheckKeyDown() && !speechBubble.IsPrinting() && currentIndex == dialogAsset.phrases.Count-1)
        {
            if (!isEnd)
            {
                endEvent.Invoke();
                isEnd = true;
            }
        }
    }

    private bool CheckKeyDown()
    {
        foreach (var key in keyList)
        {
            if (Input.GetKeyDown(key))
            {
                return true;
            }
        }

        return false;
    }
}