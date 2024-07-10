using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileStartPosition;
    private bool canShoot = true;
    public Rigidbody characterRigibody;

    private void Start()
    {
        Rigidbody characterRigibody = GetComponent<Rigidbody>();
        characterRigibody.constraints = RigidbodyConstraints.FreezeRotation; 
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileStartPosition.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Initialize(this);
        canShoot = false;
    }

    public void SetCanShoot(bool value)
    {
        canShoot = value;
    }
}
