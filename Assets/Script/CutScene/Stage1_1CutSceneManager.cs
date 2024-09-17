
using System.Collections.Generic;
using Assets.Script.UI;
using Default.Scripts.Sound;
using DG.Tweening;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class Stage1_1CutSceneManager : TextAnimationManager
{
    public List<Image> images = new List<Image>();
    public override void Initialize()
    {
        base.Initialize();
        actionDictionary.Add(0, Act0);
        actionDictionary.Add(1, Act1);
        actionDictionary.Add(2, Act2);
        actionDictionary.Add(3, Act3);
        actionDictionary.Add(5, Act5);
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }
        SoundManager.Play("CutScene", 1);
    }

    public void Act0()
    {
        images[0].gameObject.SetActive(true);
        images[0].color = Vector4.zero;
        images[0].DOColor(Color.white, 0.5f);
    }
    public void Act1()
    {
        images[0].DOColor(Vector4.zero, 0.5f).OnComplete(() =>
        {
            images[0].gameObject.SetActive(false);
        });
        images[1].gameObject.SetActive(true);
        images[1].color = Vector4.zero;
        images[1].DOColor(Color.white, 0.5f);
    }
    public void Act2()
    {
        images[1].DOColor(Vector4.zero, 0.5f).OnComplete(() =>
        {
            images[1].gameObject.SetActive(false);
        });
        images[2].gameObject.SetActive(true);
        images[2].color = Vector4.zero;
        images[2].DOColor(Color.white, 0.5f);
    }
    public void Act3()
    {
        images[2].DOColor(Vector4.zero, 0.5f).OnComplete(() =>
        {
            images[2].gameObject.SetActive(false);
        });
        images[3].gameObject.SetActive(true);
        images[3].color = Vector4.zero;
        images[3].DOColor(Color.white, 0.5f);
    }
  
    public void Act5()
    {
        images[3].DOColor(Vector4.zero, 0.5f).OnComplete(() =>
        {
            images[3].gameObject.SetActive(false);
        });
        images[0].gameObject.SetActive(true);
        images[0].color = Vector4.zero;
        images[0].DOColor(Color.white, 0.5f);
    }
}
