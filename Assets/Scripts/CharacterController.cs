using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileStartPosition;
    private bool canShoot = true;
    public Rigidbody characterRigibody;
    public PauseManager pauseManager;

    private void Start()
    {
        Rigidbody characterRigibody = GetComponent<Rigidbody>();
        characterRigibody.constraints = RigidbodyConstraints.FreezeRotation; 
        pauseManager = FindObjectOfType<PauseManager>();
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

        if(pauseManager == null) 
        {
            PauseManager.GameDefined("Dock Thing");
        }
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileStartPosition.position, transform.rotation.normalized);
        projectile.GetComponent<Projectile>().Initialize(this);
        canShoot = false;
    }

    public void SetCanShoot(bool value)
    {
        canShoot = value;
    }
}
