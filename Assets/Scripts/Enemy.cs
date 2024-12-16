
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    
    [HideInInspector] 
    public float speed;
    
    public float startHealth = 100;
    private float _health;
    
    public int worth = 50;
    
    public GameObject deathEffect;
    
    [Header("Unity Stuff")]
     public Image healthBar;
     
     
void Start()
    {
        speed = startSpeed;
        _health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        healthBar.fillAmount = _health / startHealth;
        
        if (_health <= 0)
        {
            Debug.Log("Enemy died");
            Die();
        }
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        
        //PlayerStats.money += value
        
       
        
        GameObject effect = (Instantiate(deathEffect,transform.position,Quaternion.identity));
        
        Destroy(effect, 5f);
        Spawn.EnemiesAlive--;
        
         Destroy(gameObject);
      
    }
 

}

