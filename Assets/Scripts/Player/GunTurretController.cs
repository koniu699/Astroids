using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurretController : MonoBehaviour
{
    [SerializeField]
    float cooldownTime;
    [SerializeField]
    Transform gunTurret;
    [SerializeField]
    InputController inputController;
    [SerializeField]
    ShipLifeController lifeController;
    [SerializeField]
    ObjectPool laserPool;
    [SerializeField]
    AudioSource gunAudioSource;

    bool fireEnabled = true;
    bool onCooldown = false;

    private void Awake()
    {
        inputController.onFirePressed += OnFirePressed;
        lifeController.onDeathAction += OnDeathAction;
        lifeController.onRespawnAction += OnRespawnAction;
    }

    private void OnDestroy()
    {
		inputController.onFirePressed -= OnFirePressed;
		lifeController.onDeathAction -= OnDeathAction;
		lifeController.onRespawnAction -= OnRespawnAction;
    }

    void OnFirePressed()
    {
        if (!fireEnabled || onCooldown)
            return;

		onCooldown = true;

        gunAudioSource.Play();

        var laser = laserPool.GetObjectFromPool();
        laser.SetActive(true);
        laser.transform.position = gunTurret.position;
        laser.GetComponent<LaserBeamController>().SetFireDirection(gunTurret.rotation);

        StartCoroutine(LaserCooldown(cooldownTime));
    }

    void OnDeathAction()
    {
        fireEnabled = false;
    }

    void OnRespawnAction()
    {
        fireEnabled = true;
    }

    IEnumerator LaserCooldown(float cdTime)
    {
        while (onCooldown)
        {
            yield return new WaitForSeconds(cdTime);
			onCooldown = false;
        }
    }
}
