using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yaSingleton;

[CreateAssetMenu(fileName = "Manager_", menuName = "Singletons/WaveManager")]
public class WaveManager : Singleton<WaveManager>
{
    [SerializeField] List<Wave> _waves;
    private IEnumerator<Wave> _waveIterator;
    private IEnumerator<Peasant> _peasantsIterator;
    private float _minTimeBtwPeasant = .2f;
    private Wave _currentWave;
    private int _waveNumber = 0;

    private const float MIN_TIME_BTW_PEASANTS = 1f;

    public Wave CurrentWave { get => _currentWave; }

    [ContextMenu("Start First Wave")]
    public void StartFirstWave()
    {
        _waveIterator = _waves.GetEnumerator();
        StartNextWave();
    }

    private void StartNextWave()
    {
        _waveNumber++;
        ProcWaveStartActions(_waveNumber);
        StopAllCoroutines();

        if (_waveIterator.MoveNext())
        {
            _currentWave = _waveIterator.Current;
        }
        else
        {
            Debug.Log("No more waves Available.");
            //GameManager.instance.Win();
            return;
        }

        if(_currentWave)
            StartCoroutine(COR_Wave(_currentWave));
    }

    private void ProcWaveStartActions(int waveNumber)
    {
        Debug.Log("Wave Started!" );
         // UIManager.instance.DisplayAlertMsg("Wave: " + waveNumber + "/" + _waves.Count, 2.5f);
    }


    private IEnumerator COR_Wave(Wave waveData)
    {
        yield return  Yielders.Get(waveData.RestDurationBeforeWave);
        _peasantsIterator = waveData.Peasants.GetEnumerator();

        while (_peasantsIterator.MoveNext())
        {
            var peasant = _peasantsIterator.Current;
            yield return new WaitForSeconds(MIN_TIME_BTW_PEASANTS);

            EnemyManager.Instance.InitEnemy(peasant);
        }
        Debug.Log("Wave Started!" );
        //yield return StartCoroutine(COR_WaitForWaveCleanUp());
        yield return Yielders.Get(1f);

        Debug.Log("Wave Completed!");
        //GameManager.Instance.WavesConquered++;??
        StartNextWave();
    }
    
    /*
    private IEnumerator COR_WaitForWaveCleanUp()
    {
        while(AreAllPeasantsDeathOrHealed() == false)
        {
            Debug.Log("Check!");
            yield return Yielders.Get(1.5f);
        }
    }*/
}
