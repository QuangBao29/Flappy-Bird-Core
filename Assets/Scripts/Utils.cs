using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Threading.Tasks;

public static class Utils
{
    public static T InstantiateObject<T>(T prefab, Transform parent) where T : Component
    {
        if (prefab != null)
        {
            T go = GameObject.Instantiate<T>(prefab) as T;
            go.transform.SetParent(parent);
            go.transform.localScale = Vector3.one;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localPosition = Vector3.zero;
            go.gameObject.SetActive(false);
            return go;
        }
        return null;
    }

    //LOAD AUDIO
    public static AudioClip LoadAudioClip(string filePath)
    {
        var www = new WWW("file://" + filePath);

        while (!www.isDone) { }

        return www.GetAudioClip(false, false);
    }
}
