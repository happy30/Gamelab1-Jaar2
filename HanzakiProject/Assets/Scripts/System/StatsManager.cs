//StatsManager by Jordi

using UnityEngine;
using System.Collections;

public class StatsManager : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public int health;
    public int maxHealth;

    public bool katanaUnlocked;
    public bool grapplingHookUnlocked;
    public bool shurikenUnlocked;
    public bool smokeBombUnlocked;

    public int shurikenAmount;
    public int smokeBombAmount;

    public void GetLife()
    {
        maxHealth++;
        health++;
    }

    public void GetHealth()
    {
        if(health < maxHealth)
        {
            health++;
        }
    }
}
