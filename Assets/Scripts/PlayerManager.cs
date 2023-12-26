
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health = 100f;
    public Text healthText;
    public GameManager gameManager;
    

    public void Hit(float damage)
    {
        health -= damage;
        healthText.text =  "Health: " + health.ToString();
        if (health <= 0)
        {
            gameManager.EndGame();
        }

       
    }
}
