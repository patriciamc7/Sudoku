using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public enum EGameMode
    {
        NOT_SET,
        Easy,
        Medium,
        Hard,
        VeryHard
    }

    public static GameSettings Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(Instance);
    }

    private EGameMode _GameMode;

    private void Start()
    {
        _GameMode = EGameMode.NOT_SET;
    }

    public void SetGameMode(EGameMode aMode)
    {
        _GameMode = aMode; 
    }

    public void SetGameMode(string aMode)
    {
        EGameMode setMode;
        if (Enum.TryParse(aMode, out setMode) && setMode != EGameMode.NOT_SET)
            SetGameMode(setMode);
        else SetGameMode(EGameMode.NOT_SET);
    }

    public string GetGameMode()
    {
        return _GameMode.ToString();
    }
}
