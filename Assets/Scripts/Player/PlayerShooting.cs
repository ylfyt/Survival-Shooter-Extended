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
         foreach (var G in gunLineList)
        {
            G.enabled = false;
        }
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

        if(gunDirectionLevel == 2 ){
            gunLine2.enabled = true;
            gunLine2.SetPosition(0, gunPoint.position);
            gunLine2.SetPosition(1, gunPoint.position + Quaternion.Euler(0, -23, 0) * gunPoint.forward * range );


            gunLine3.enabled = true;
            gunLine3.SetPosition(0, gunPoint.position);
            gunLine3.SetPosition(1, gunPoint.position + Quaternion.Euler(0, 23, 0) * gunPoint.forward * range );

            gunLineList.Add(gunLine2);
            gunLineList.Add(gunLine3);
        }
        else if (gunDirectionLevel == 3){
            gunLine2.enabled = true;
            gunLine2.SetPosition(0, gunPoint.position);
            gunLine2.SetPosition(1, gunPoint.position + Quaternion.Euler(0, -23, 0) * gunPoint.forward * range );


            gunLine3.enabled = true;
            gunLine3.SetPosition(0, gunPoint.position);
            gunLine3.SetPosition(1, gunPoint.position + Quaternion.Euler(0, 23, 0) * gunPoint.forward * range );

            gunLine4.enabled = true;
            gunLine4.SetPosition(0, gunPoint.position);
            gunLine4.SetPosition(1, gunPoint.position + Quaternion.Euler(0, -45, 0) * gunPoint.forward * range );


            gunLine5.enabled = true;
            gunLine5.SetPosition(0, gunPoint.position);
            gunLine5.SetPosition(1, gunPoint.position + Quaternion.Euler(0, 45, 0) * gunPoint.forward * range );

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