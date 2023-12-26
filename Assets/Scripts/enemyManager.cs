
using UnityEngine;
using UnityEngine.AI;

public class enemyManager : MonoBehaviour
{

    public GameObject player;
    public Animator enemyAnimator;
    public float damage = 20f;
    public float ZombieHealth = 100f;
    public GameManager gameManager;
    private AudioSource ZombieAliveSound;
    private AudioSource ZombieDeadSound;

    public void Hit(float damage)
    {
        ZombieHealth -= damage;
        if (ZombieHealth <= 0f )
        {
            gameManager.enemiesAlive--;
            ZombieDeadSound.Play();
            enemyAnimator.SetBool("isDead", true);
            
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnimator = GetComponent<Animator>();
        ZombieAliveSound = GetComponent<AudioSource>();
        ZombieDeadSound = GetComponent<AudioSource>();
    }


    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {

            enemyAnimator.SetBool("isWalking", true);

        }
        else
        {
            enemyAnimator.SetBool("isWalking", false);
           
        }

        if(ZombieHealth > 0f)
        {
            ZombieAliveSound.Play();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {

            Debug.Log("Hitted");
            player.GetComponent<PlayerManager>().Hit(damage);
            
        }
    }
}
