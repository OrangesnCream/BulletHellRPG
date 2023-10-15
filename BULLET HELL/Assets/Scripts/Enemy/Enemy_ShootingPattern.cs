using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ShootingPattern : MonoBehaviour
{
    private List<Transform> children;
    public List<ParticleSystem> particleSystems;
    public float opportunitycheck;
    private float shootopportunity;
    void Start()
    {
        children = GetChildren(transform);

         foreach(Transform child in children)
         {
            particleSystems.Add(child.GetComponent<ParticleSystem>());
         }

    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();

        foreach (Transform child in parent)
        {
            children.Add(child);
        }
        return children;
    }

    private void FixedUpdate()
    {
        shootopportunity++;

        if (shootopportunity >= opportunitycheck)
        {
            foreach (ParticleSystem particle in particleSystems)
            {
                if (particle.isPlaying)
                {
                    particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                }
                else
                {
                    particle.Play();
                }
            }
            shootopportunity = 0;
        }
    }

    public void setFireRate(int rate)
    {
        foreach(ParticleSystem particle in particleSystems)
        {
            var emission = particle.emission;
            emission.rateOverTime = rate;
        }
    }

    public void setBulletSpeed(float speed)
    {
        foreach (ParticleSystem particle in particleSystems)
        {
            var mainModule = particle.main;
            mainModule.startSpeed = speed;
        }
    }

    public float getFireRate()
    {
        var emission = particleSystems[0].emission;
        return emission.rateOverTime.constant;
    }

    public float getBulletSpeed()
    {
        var mainModule = particleSystems[0].main;
        return mainModule.startSpeed.constant;
    }
}