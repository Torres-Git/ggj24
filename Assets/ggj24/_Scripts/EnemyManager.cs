using System.Collections.Generic;
using UnityEngine;
using yaSingleton;

[CreateAssetMenu(fileName = "Manager_", menuName = "Singletons/EnemyManager")]
public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] EnemyAI _enemyPrefab;
    [SerializeField] int _enemyAmount;
    [SerializeField] Vector3 _enemyRightPos;
    [SerializeField] Vector3 _enemyLeftPos;
    [SerializeField] bool _areEnemiesReady = false;

    private List<EnemyAI> _enemies = new List<EnemyAI>();
    public bool AreEnemiesReady { get => _areEnemiesReady;  }

    protected override void Initialize()
    {
        base.Initialize();
        
       var parent= new GameObject("Enemy Parent");
        Debug.Log("EnemyManager Init");

        for (int i = 0; i < _enemyAmount; i++)
        {
            var enemy = Instantiate(_enemyPrefab, parent.transform);
            if(i%2 == 0)
            {
                enemy.transform.position = _enemyRightPos;
                enemy.EnemySprite.flipX = true;

            }else
            {
                enemy.transform.position =_enemyLeftPos;
                enemy.EnemySprite.flipX = false;
            }
            _enemies.Add(enemy);
        }

        _areEnemiesReady = true;
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

