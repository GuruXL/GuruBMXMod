using UnityEngine;
using MelonLoader;
using Il2Cpp;
using HarmonyLib;
using Il2CppMG_Gameplay;
using System.Collections.Generic;
using System.Collections;
using GuruBMXMod.Multi;

namespace GuruBMXMod
{
    public class TestMono : MonoBehaviour
{
    private static TestMono _instance;
    public static TestMono Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TestMono>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("TestMonoSingleton");
                    _instance = singletonObject.AddComponent<TestMono>();
                    DontDestroyOnLoad(singletonObject);
                    MelonLogger.Msg("TestMono Instance Created");
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            MelonLogger.Msg("TestMono Instance Created");
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
}
}
