using UnityEngine;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviour
{
    public PlayerAttribute playerAttribute;
    public int damagePerShot = 10;
    public float timeBetweenBullets = 0.2f;
    public float range = 100f;
    public Transform gunPoint;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    public LineRenderer gunLine;
    public LineRenderer gunLine2;
    public LineRenderer gunLine3;
    public LineRenderer gunLine4;
    public LineRenderer gunLine5;


    public int gunDirectionLevel = 1;
    public List<LineRenderer> gunLineList = new List<LineRenderer>();

    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        // gunLine = GetComponent<LineRenderer>();
        // gunLine2 = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        gunLight.enabled = false;
        foreach (var G in gunLineList)
        {
            G.enabled = false;
        }
    }

    public void setDirection(LineRenderer line, int degree)
    {
        line.SetPosition(0, gunPoint.position);
        line.SetPosition(1, gunPoint.position + Quaternion.Euler(0, degree, 0) * gunPoint.forward * range);
    }

    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();
        gunLight.enabled = true;
        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, gunPoint.position);
        gunLineList.Add(gunLine);

        if (gunDirectionLevel == 2)
        {
            gunLine2.enabled = true;
            setDirection(gunLine2, -23);

            gunLine3.enabled = true;
            setDirection(gunLine3, 23);

            gunLineList.Add(gunLine2);
            gunLineList.Add(gunLine3);
        }

        else if (gunDirectionLevel == 3)
        {
            gunLine2.enabled = true;
            setDirection(gunLine2, -23);

            gunLine3.enabled = true;
            setDirection(gunLine3, 23);

            gunLine4.enabled = true;
            setDirection(gunLine4, -45);

            gunLine5.enabled = true;
            setDirection(gunLine5, 45);


            gunLineList.Add(gunLine4);
            gunLineList.Add(gunLine5);
        }


        shootRay.origin = gunPoint.position;
        shootRay.direction = gunPoint.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(playerAttribute.power * damagePerShot, shootHit.point);
            }

            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}