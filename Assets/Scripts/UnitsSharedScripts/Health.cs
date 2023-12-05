using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    
    // Start is called before the first frame update    
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            if (this.CompareTag("Tree") && !GameValueManager.INSTANCE.gameWon)
            {
                GameValueManager.INSTANCE.treeIsALive = false;
                this.GetComponent<TreeScript>().WiltingTree();
                StartCoroutine(YieldDie());
            }
            else
            {
                Die();                
            }
        }            
    }
    public IEnumerator YieldDie()
    {
        yield return new WaitForSeconds(0.1f);
        Die();
    }
    public void Die()
    {
        if (this.CompareTag("Tree"))
            this.GetComponent<SpriteRenderer>().enabled = false;
        else
            Destroy(gameObject);
    }

}
