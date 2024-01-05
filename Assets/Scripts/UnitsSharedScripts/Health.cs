using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public bool isCentipede;
    public enum Type { normal, Boss}
    public Type type;
    public Slider slider;
    private void Update()
    {
        if (type == Type.Boss)
        {
            slider.maxValue = maxHealth;
            slider.value = currentHealth;
            return;
        }
    }
    // Start is called before the first frame update    
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void HealToMax()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            if(type == Type.Boss)
            {

                return;
            }
            if (this.CompareTag("Tree") && !GameValueManager.INSTANCE.gameWon)
            {
                GameValueManager.INSTANCE.treeIsALive = false;
                this.GetComponent<TreeScript>().WiltingTree();
                StartCoroutine(YieldDie(0.1f));
            }
            else if (isCentipede)
            {
                StartCoroutine(YieldDie(0.5f));
                //GameValueManager.INSTANCE.IncreaseProgress();
            }
            else
                Die();
                GameValueManager.INSTANCE.IncreaseProgress();
        }            
    }
    public IEnumerator YieldDie(float waitTime)
    {        
        yield return new WaitForSeconds(waitTime);
        Die();
    }
    public void Die()
    {           
            Destroy(gameObject);
    }

}
