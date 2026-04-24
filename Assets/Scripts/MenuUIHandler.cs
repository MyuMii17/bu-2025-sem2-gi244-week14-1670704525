using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public int mainSceneIndex = 1;
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        MainManager.GetInstance().TeamColor = color;
    }

    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        ColorPicker.SelectColor(MainManager.GetInstance().TeamColor);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(mainSceneIndex);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif         
    }

    public void SaveColorClicked()
    {
        MainManager.GetInstance().SaveColor();
    }

    public void LoadColorClicked()
    {
        MainManager.GetInstance().LoadColor();
        ColorPicker.SelectColor(MainManager.GetInstance().TeamColor);
    }
}
