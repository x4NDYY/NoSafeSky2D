using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
    [Header("Ammo")]
    public int magazineSize = 30;
    public int ammoInReserve = 120;

    int currentAmmo;

    [Header("Reload")]
    public float reloadTime = 1.2f;

    [Header("Audio")]
    public AudioSource shootAudio;
    public AudioSource emptyAudio;
    public AudioSource reloadAudio;

    ShootHitScan hitScan;

    bool isReloading = false;

    GunTracer tracer;

    void Awake()
    {
        currentAmmo = magazineSize;
        tracer = GetComponent<GunTracer>();
        hitScan = GetComponent<ShootHitScan>();

    }

    void Update()
    {
        if (GameManager.IsGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (!isReloading && Input.GetMouseButtonDown(0))
            TryShoot();
    }


    void TryShoot()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            emptyAudio.PlayOneShot(emptyAudio.clip);
            return;
        }

        currentAmmo--;

        tracer.Shoot();
        hitScan.Shoot();

        shootAudio.PlayOneShot(shootAudio.clip);
    }


    IEnumerator Reload()
    {
        if (ammoInReserve <= 0 || currentAmmo == magazineSize)
            yield break;

        isReloading = true;

        shootAudio.Stop();   // ← ВАЖНО
        emptyAudio.Stop();   // ← тоже

        reloadAudio.Play();

        yield return new WaitForSeconds(reloadTime);

        int needed = magazineSize - currentAmmo;
        int take = Mathf.Min(needed, ammoInReserve);

        currentAmmo += take;
        ammoInReserve -= take;

        isReloading = false;
    }


    // для UI потом
    public int GetCurrentAmmo() => currentAmmo;
    public int GetReserveAmmo() => ammoInReserve;
}
