using System.Collections;
using UnityEngine;
using yaSingleton;

[CreateAssetMenu(fileName = "Manager_", menuName = "Singletons/GameManager")]
public class GameManager : Singleton<GameManager>
{
    [SerializeField] int _score;
    [SerializeField] int _castleMaxHitPoints = 2;
    [SerializeField] float _castleAutoRegenDelay = 0f;

    [SerializeField] int _castleCurrentHitPoints;
    public int Score { get => _score;  }

    protected override void Initialize()
    {
        base.Initialize();
        _castleCurrentHitPoints = _castleMaxHitPoints;
       var enemyManager = GetOrCreate<EnemyManager>();
       var waveManager = GetOrCreate<WaveManager>();
        
        StartCoroutine(COR_WaveDelay(waveManager,enemyManager));

        if(_castleAutoRegenDelay > 0 )
            StartCoroutine(COR_AutoRegenCastle());
    }

    IEnumerator COR_WaveDelay(WaveManager waveManager, EnemyManager enemyManager)
    {
        yield return new WaitUntil(()=> enemyManager.AreEnemiesReady);
        yield return Yielders.EndOfFrame;
        
        waveManager.StartFirstWave(enemyManager);
    }

    IEnumerator COR_AutoRegenCastle()
    {
        if(_castleAutoRegenDelay <= 0 ) yield break;

        while(true)
        {
            yield return Yielders.Get(_castleAutoRegenDelay);
            HealCastle(1);
        }
    }

    public int HealCastle(int healAmount)
    {
        if(_castleCurrentHitPoints < _castleMaxHitPoints)
        {
            _castleCurrentHitPoints += healAmount;
           if( _castleCurrentHitPoints > _castleMaxHitPoints)
            _castleCurrentHitPoints = _castleMaxHitPoints;
        }
        return _castleCurrentHitPoints;
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
