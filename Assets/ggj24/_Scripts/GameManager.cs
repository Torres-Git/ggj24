using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using yaSingleton;

[CreateAssetMenu(fileName = "Manager_", menuName = "Singletons/GameManager")]
public class GameManager : Singleton<GameManager>
{

    protected override void Initialize()
    {
        base.Initialize();
       var w = GetOrCreate<WaveManager>();
        w.StartFirstWave();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
    }

    protected override void Deinitialize()
    {
        base.Deinitialize();
    }
}
