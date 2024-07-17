using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileStartPosition;
    private bool canShoot = true;
    private Rigidbody characterRigidbody;
    private PauseManager pauseManager;
    public AudioClip shurikenSound;
    private AudioSource playerAudio;
    private LifeCounter lifeCounter;

    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        characterRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        pauseManager = GameObject.Find("Canvas")?.GetComponent<PauseManager>();
        playerAudio = GetComponent<AudioSource>();
        lifeCounter = GameObject.Find("Canvas")?.GetComponent<LifeCounter>();

        if (pauseManager == null)
        {
            Debug.LogError("PauseManager not found on Canvas object");
        }

        if (lifeCounter == null)
        {
            Debug.LogError("LifeCounter not found on Canvas object");
        }
    }

    void Update()
    {
        if (pauseManager != null && pauseManager.IsPaused())
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject canvas = GameObject.Find("Canvas");
            LifeCounter lifeCounter = canvas.GetComponent<LifeCounter>();
            lifeCounter.LoseLife();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameObject canvas = GameObject.Find("Canvas");
            LifeCounter lifeCounter = canvas.GetComponent<LifeCounter>();
            lifeCounter.LoseLife();
        }
    }
}
