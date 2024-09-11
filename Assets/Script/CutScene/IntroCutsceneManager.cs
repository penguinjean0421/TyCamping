
using System.Collections.Generic;
using DG.Tweening;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroCutsceneManager : TextAnimationManager
{
    public List<Image> cartoonCuts = new List<Image>();
    public List<Image> charaters = new List<Image>();
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
    }

    public void Act0()
    {
        cartoonCuts[0].gameObject.SetActive(true);
       
    }
    public void Act1()
    {
        charaters[0].gameObject.SetActive(true);
        charaters[0].transform.position = charaters[0].transform.position + Vector3.left*150;
        charaters[0].transform.DOMoveX(150,0.5f).SetRelative();
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
        charaters[1].transform.position = charaters[1].transform.position + Vector3.down * 300;
        charaters[1].transform.DOMoveY(300, 0.5f).SetDelay(0.3f).SetRelative().SetEase(Ease.OutBack);
        charaters[0].transform.DOMoveX(-500, 0.5f).SetRelative();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Stage1_1");
    }
}
