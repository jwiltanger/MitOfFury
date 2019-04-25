using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 1;
    public int curHealth = 1;

    // Update is called once per frame
    void Update()
    {
        AdjustCurrentHealth(0);
    }
    public void AdjustCurrentHealth(int adj)
    {
        curHealth += adj;

        if (curHealth < 0)
        {
            curHealth = 0;
            gameObject.SetActive(false);
        }

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (maxHealth < 1)
            maxHealth = 1;
    }
}
