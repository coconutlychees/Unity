using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject muzzle;
    public Transform barrel;
    public AudioClip shotsounds;
    public AudioClip popsounds;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        AudioSource.PlayClipAtPoint(shotsounds, barrel.position, 0.5f);
        Instantiate(muzzle, barrel.position, Quaternion.identity, barrel);

        RaycastHit hit;
        Vector3 shotOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(shotOrigin, Camera.main.transform.forward, out hit, 100))
        {
            if (hit.collider.GetComponent<Balloon>())
            {
                hit.collider.GetComponent<Balloon>().OnHit();
                AudioSource.PlayClipAtPoint(popsounds, hit.transform.position);
                return;
            }
            if (hit.collider.GetComponent<Rigidbody>() && hit.collider.tag != "Player")
            {
                hit.collider.GetComponent<Rigidbody>().AddExplosionForce(100, hit.point, 5);
            }
        }

    }

}
