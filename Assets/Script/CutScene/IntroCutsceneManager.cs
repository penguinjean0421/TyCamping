
using System.Collections.Generic;
using Assets.Script.UI;
using Default.Scripts.Sound;
using DG.Tweening;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroCutsceneManager : TextAnimationManager
{
    public List<Image> cartoonCuts = new List<Image>();
    public List<Image> charaters = new List<Image>();
    public MileStone mileStone;
    public override void Initialize()
    {
        base.Initialize();
        actionDictionary.Add(0, Act0);
        actionDictionary.Add(1, Act1);
        actionDictionary.Add(2, Act2);
        actionDictionary.Add(3, Act3);
        actionDictionary.Add(5, Act5);
        actionDictionary.Add(6, Act6);
        actionDictionary.Add(10, Act10);
        foreach (Image image in cartoonCuts)
        {
            image.gameObject.SetActive(false);
        }
        foreach (Image image in charaters)
        {
            image.gameObject.SetActive(false);
        }
        SoundManager.Play("CutScene", 1);
    }

    public void Act0()
    {
        cartoonCuts[0].gameObject.SetActive(true);
       
    }
    public void Act1()
    {
        charaters[0].gameObject.SetActive(true);
        charaters[0].rectTransform.DOAnchorPosX(100, 0.5f);
    }
    public void Act2()
    {
        cartoonCuts[1].gameObject.SetActive(true);
    }
    public void Act3()
    {
        cartoonCuts[2].gameObject.SetActive(true);
    }
  
    public void Act5()
    {
        cartoonCuts[3].gameObject.SetActive(true);
    }

    public void Act6()
    {
        cartoonCuts[4].gameObject.SetActive(true);
    }
    public void Act10()
    {
        charaters[1].gameObject.SetActive(true);
        charaters[1].rectTransform.DOAnchorPosY(180, 0.5f).SetDelay(1f).SetEase(Ease.OutBack);
        charaters[0].rectTransform.DOAnchorPosX(-200, 0.5f);
    }
    public void StartGame()
    {
        mileStone.Initialize();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(mileStone.Stamp());
        sequence.Append(mileStone.Animate());
        sequence.AppendInterval(3.0f);
        sequence.AppendCallback(() =>
        {
            SceneManager.LoadScene("Stage1_1");
        });
        sequence.Play();
    }
}
