using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileStartPosition;
    private bool canShoot = true;
    public Rigidbody characterRigibody;
    private PauseManager pauseManager;
    public AudioClip shurikenSound;
    private AudioSource playerAudio;


    private void Start()
    {
        Rigidbody characterRigibody = GetComponent<Rigidbody>();
        characterRigibody.constraints = RigidbodyConstraints.FreezeRotation;
        pauseManager = GameObject.Find("Canvas").GetComponent<PauseManager>();
        playerAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (pauseManager.IsPaused()) 
        {
        return;
        }

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileStartPosition.position, transform.rotation.normalized);
        projectile.GetComponent<Projectile>().Initialize(this);
        playerAudio.PlayOneShot(shurikenSound, 1.0f);
        canShoot = false;
    }

    public void SetCanShoot(bool value)
    {
        canShoot = value;
    }
}
