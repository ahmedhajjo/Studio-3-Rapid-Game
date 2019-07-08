﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayActions : MonoBehaviour
{
    public GameEvent onBegin;
    public GameEvent onEnd;
    public int maxRuns = 3;
    public int runsOver;
    public virtual void Begin()
    {
        onBegin.Raise();
    }

    public abstract bool IsRunning();

    public virtual void Done()
    {
        onEnd.Raise();
    }


}



