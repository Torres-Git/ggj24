using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using yaSingleton;

[CreateAssetMenu(fileName = "Manager_", menuName = "Singletons/GameManager")]
public class GameManager : Singleton<GameManager>
{
    [SerializeField] bool _isPlayable = true;
    [SerializeField] int _score;
    [SerializeField] int _castleMaxHitPoints = 2;
    [SerializeField] float _castleAutoRegenDelay = 0f;

    [SerializeField] int _castleCurrentHitPoints;
    private StageManager _stageManager;
    private EnemyManager _enemyManager;
    private WaveManager _waveManager;
    public int Score { get => _score;  }

    protected override void Initialize()
    {
        base.Initialize();
        
       _enemyManager = GetOrCreate<EnemyManager>();
       _waveManager = GetOrCreate<WaveManager>();
    }

    public void StartSequence(StageManager stageManager)
    {
        StopAllCoroutines();
        StartCoroutine(COR_StartSequence(stageManager,_waveManager, _enemyManager));
    }

   private IEnumerator COR_StartSequence(StageManager stageManager, WaveManager waveManager, EnemyManager enemyManager)
    {
        _stageManager = stageManager;

        if (_castleAutoRegenDelay > 0)
            StartCoroutine(COR_AutoRegenCastle());

        _castleCurrentHitPoints = _castleMaxHitPoints;

        yield return Yielders.Get(1f);
        _enemyManager.ReadyEnemies();

        Debug.Log("enemyManager.AreEnemiesReady:" + enemyManager.AreEnemiesReady);

        // Start the first wave and perform other actions
        waveManager.StartFirstWave(enemyManager);
        _stageManager.AddSpears();
        _isPlayable = true;
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
        if(!_isPlayable) return _castleCurrentHitPoints;

        if(_castleCurrentHitPoints < _castleMaxHitPoints)
        {
            _castleCurrentHitPoints += healAmount;
           if( _castleCurrentHitPoints > _castleMaxHitPoints)
            _castleCurrentHitPoints = _castleMaxHitPoints;
            _stageManager.AddSpears();
            
        }
        return _castleCurrentHitPoints;
    }
    

    public void DamageCastle(int damageAmount)
    {
        if(!_isPlayable) return;
        _stageManager.RemoveSpears();
            _castleCurrentHitPoints -= damageAmount;
        
        if(_castleCurrentHitPoints <= 1)
            _stageManager.BounceCastle();

        if(_castleCurrentHitPoints <= 0)
          Lose();

    }

    private void Lose()
    {
        if(!_isPlayable) return;
        _isPlayable = false;
        StartCoroutine(COR_LoseSequence());
    }

    private IEnumerator COR_LoseSequence()
    {
        Debug.Log("You almost Lost");

        _stageManager.InCurtain();

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Reset enemies and waves
        WaveManager.Instance.ResetWaves();
        EnemyManager.Instance.ResetEnemies();

        // Get the current scene index and reload the scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
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
