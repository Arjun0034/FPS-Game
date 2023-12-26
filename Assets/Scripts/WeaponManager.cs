
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Camera gun;
    public float range = 100f;
    public float damage = 25f;
    public Animator playerAnimator;
    public AudioSource gunSound;
    public LayerMask enemyLayer;


    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        gunSound = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        
        if (Input.GetMouseButton(0)) 
        {
            Shoot();
            gunSound.Play();
            playerAnimator.SetBool("isShooting", true);
            

        }
        else
        {
            playerAnimator.SetBool("isShooting", false);
            gunSound.Stop();
        }

        


    }

    void Shoot()
    {
        

        RaycastHit hit;

        if(Physics.Raycast(gun.transform.position, gun.transform.forward, out hit, range, enemyLayer))
        {
            Debug.Log("Raycast hit: " + hit.transform.name);

            enemyManager EnemyManager = hit.transform.GetComponent<enemyManager>();
            if (EnemyManager != null)
            {
                EnemyManager.Hit(damage);
                Debug.Log(hit.transform.name);
                Debug.DrawRay(gun.transform.position, gun.transform.forward * range, Color.blue);
            }
            else
            {
                Debug.DrawRay(gun.transform.position, gun.transform.forward * range, Color.red);
            }
        }
    }
}
