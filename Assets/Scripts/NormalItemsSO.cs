using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalItemsSO", menuName = "NormalItemsSO", order = 0)]
public class NormalItemsSO : ScriptableObject
{
    public Sprite[] sprites;

    private void OnValidate()
    {
        var length = Constants.PREFAB_NORMAL_NAMES.Length;
        if (sprites.Length != length) Array.Resize(ref sprites, length);
    }
}
