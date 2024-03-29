﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu()]
public class GameEvent : ScriptableObject
{
    public UnityEvent onRaise;
    public void Raise()
    {
        onRaise.Invoke();
    }
}
