using UnityEngine;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviour
{
    public PlayerAttribute playerAttribute;
    public GameObject hitParticle;
    public int damagePerShot = 10;
    public float timeBetweenBullets = 0.2f;
    public float range = 100f;
    public Transform gunPoint;

    float timer;
    Ray shootRay;
    Ray shootRay2;
    Ray shootRay3;
    Ray shootRay4;
    Ray shootRay5;
    public List<Ray> shootRayList = new List<Ray>();

    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    public LineRenderer gunLine;
    public LineRenderer gunLine2;
    public LineRenderer gunLine3;
    public LineRenderer gunLine4;
    public LineRenderer gunLine5;
    public List<LineRenderer> gunLineList = new List<LineRenderer>();


    public int gunDirectionLevel = 1;

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
        gunLineList.Add(line);
    }

    public void setShootRay(Ray shootRay, int degree){
        shootRay.origin = gunPoint.position;
        shootRay.direction = Quaternion.Euler(0, degree, 0) * gunPoint.forward;
        shootRayList.Add(shootRay);
    }

    void Shoot()
    {
        timer = 0f;
        gunLineList.Clear();
        shootRayList.Clear();

        gunAudio.Play();
        gunLight.enabled = true;
        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        setDirection(gunLine, 0);
        setShootRay(shootRay, 0);


        if (gunDirectionLevel == 2)
        {
            gunLine2.enabled = true;
            setDirection(gunLine2, -23);
            setShootRay(shootRay2 ,-23);

            gunLine3.enabled = true;
            setDirection(gunLine3, 23);
            setShootRay(shootRay3 ,23);

        }

        else if (gunDirectionLevel == 3)
        {
     
            gunLine2.enabled = true;
            setDirection(gunLine2, -23);
            setShootRay(shootRay2 ,-23);

            gunLine3.enabled = true;
            setDirection(gunLine3, 23);
            setShootRay(shootRay3 ,23);

            gunLine4.enabled = true;
            setDirection(gunLine4, -45);
            setShootRay(shootRay4, -45);


            gunLine5.enabled = true;
            setDirection(gunLine5, 45);
            setShootRay(shootRay5, 45);

        }


       for (int i = 0; i < shootRayList.Count; i++) {
          var SR = shootRayList[i];
          if (Physics.Raycast(SR, out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(playerAttribute.power * damagePerShot, shootHit.point);
                }

                
                gunLineList[i].SetPosition(1, shootHit.point);
                var hitEffect = Instantiate(hitParticle, shootHit.point, Quaternion.LookRotation(shootHit.normal));
                Destroy(hitEffect, .3f);
            
                // gunLine.SetPosition(1, shootHit.point);
                // var hitEffect = Instantiate(hitParticle, shootHit.point, Quaternion.LookRotation(shootHit.normal));
                // Destroy(hitEffect, .3f);
            }
            else
            {
                gunLineList[i].SetPosition(1, SR.origin + SR.direction * range);
            }
        
        }
           
    }   
    
}