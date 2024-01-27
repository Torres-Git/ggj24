using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yaSingleton;

[CreateAssetMenu(fileName = "Manager_", menuName = "Singletons/EnemyManager")]
public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] EnemyAI _enemyPrefab;
    [SerializeField] int _enemyAmount;
    private List<EnemyAI> _enemies;
    [SerializeField] Vector3 _enemyRightPos;
    [SerializeField] Vector3 _enemyLeftPos;

    protected override void Initialize()
    {
        var parent = Instantiate(new GameObject("Enemy Parent"));

        for (int i = 0; i < _enemyAmount; i++)
        {
            var enemy = Instantiate(_enemyPrefab,parent.transform);
            enemy.transform.position = (i%2 == 0)? _enemyRightPos: _enemyLeftPos;
            _enemies.Add(enemy);
        }

        base.Initialize();
    }


    public void InitEnemy(Peasant peasantData)
    {
        if(_enemies.Count == 0) return;
        
        foreach (var enemy in _enemies)
        {
            if(enemy.IsAvailable)
            {
                enemy.Init(peasantData);
                return;
            }
        }
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

