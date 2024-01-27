using System.Collections;
using UnityEngine;
using yaSingleton;

[CreateAssetMenu(fileName = "Manager_", menuName = "Singletons/GameManager")]
public class GameManager : Singleton<GameManager>
{
    protected override void Initialize()
    {
        base.Initialize();

       var enemyManager = GetOrCreate<EnemyManager>();
       var waveManager = GetOrCreate<WaveManager>();
        
        StartCoroutine(COR_WaveDelay(waveManager,enemyManager));
    }

    IEnumerator COR_WaveDelay(WaveManager waveManager, EnemyManager enemyManager)
    {
        yield return new WaitUntil(()=> enemyManager.AreEnemiesReady);
        yield return Yielders.EndOfFrame;
        
        waveManager.StartFirstWave(enemyManager);
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
