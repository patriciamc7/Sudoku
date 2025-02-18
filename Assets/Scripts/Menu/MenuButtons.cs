using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void LoadScene(string aName)
    {
        SceneManager.LoadScene(aName);
    }

    public void LoadEasyScene(string aName)
    {
        GameSettings.Instance.SetGameMode(GameSettings.EGameMode.Easy);
        SceneManager.LoadScene(aName);
    }

    public void LoadMediumScene(string aName)
    {
        GameSettings.Instance.SetGameMode(GameSettings.EGameMode.Medium);
        SceneManager.LoadScene(aName);
    }

    public void LoadHardScene(string aName)
    {
        GameSettings.Instance.SetGameMode(GameSettings.EGameMode.Hard);
        SceneManager.LoadScene(aName);
    }

    public void LoadVeryHardScene(string aName)
    {
        GameSettings.Instance.SetGameMode(GameSettings.EGameMode.VeryHard);
        SceneManager.LoadScene(aName);
    }

    public void ActivateObject(GameObject aObject)
    {
        aObject.SetActive(true);
    }
    
    public void DeactivateObject(GameObject aObject)
    {
        aObject.SetActive(false);
    }
}