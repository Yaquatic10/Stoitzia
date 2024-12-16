using System.Collections;

using UnityEngine;
using TMPro;


public class Spawn : MonoBehaviour
{
  
    public static int EnemiesAlive = 0;

    public Waves[] waves;
    
    
    public Transform spawnPoint;
    
    
    
    public float timeBetweenWaves = 5f;
    public float countdown = 2f;

    public TextMeshProUGUI contador ;
  
    private int _waveNumber = 1;
    
  
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        
        
        if (countdown <= 0f)
        {
            
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            
        }
        countdown -= Time.deltaTime;

        countdown =Mathf.Clamp(countdown,0f,Mathf.Infinity);
        
        contador.text = string.Format("{0:0.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        //PlayerStats.Rounds++;
        Waves wave = waves[_waveNumber - 1];
        
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        _waveNumber++;

        if (_waveNumber == waves.Length)
        {
            Debug.Log("level wonnnnnn");
            this.enabled = false;
        }
        
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
        EnemiesAlive++;
    }
}
