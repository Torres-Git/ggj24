using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using yaSingleton;

[CreateAssetMenu(fileName = "Manager_", menuName = "Singletons/GameManager")]
public class GameManager : Singleton<GameManager>
{
    private int _score = 0;


    public UnityEvent<int> OnScoreChange = new UnityEvent<int>();

    public int Score { get => _score; }
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

    public void AddScore(int ammount)
    {
        _score += ammount;
        OnScoreChange.Invoke(_score);
    }

    public void RemoveScore(int ammount)
    {
        _score -= ammount;
        if(_score <= 0)
        {
            _score = 0;
        }
        OnScoreChange.Invoke(_score);
    }
}
