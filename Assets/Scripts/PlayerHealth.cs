using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetButtonDown("Jump")){
            TakeDamage(20);
        }
        */
    }
    public void TakeDamage(int _damage)
    {
        currentHealth-=_damage;

        if(currentHealth<0){currentHealth=0;}

        healthBar.SetHealth(currentHealth);
    }
}
