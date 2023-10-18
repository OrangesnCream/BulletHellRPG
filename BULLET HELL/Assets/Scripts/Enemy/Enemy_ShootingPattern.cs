using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ShootingPattern : MonoBehaviour
{
    private List<Transform> children;
    public List<ParticleSystem> particleSystems;
    private bool canShoot;
    private void Start()
    {
        children = GetChildren(transform);

         foreach(Transform child in children)
         {
            particleSystems.Add(child.GetComponent<ParticleSystem>());
         }
    }

    private List<Transform> GetChildren(Transform parent)
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
        if (canShoot)
        {
            foreach(ParticleSystem particleSystem in particleSystems)
            {
                particleSystem.Play();
            }
        }
        else
        {
            foreach (ParticleSystem particleSystem in particleSystems)
            {
                particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        }
    }

    public void setCanShoot(bool canShoot) { this.canShoot = canShoot; }

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

    public void setSize(float size)
    {
        foreach (ParticleSystem particle in particleSystems)
        {
            var mainModule = particle.main;
            mainModule.startSize = size;
        }
    }

    public void setBounce(int bounce)
    {
        foreach (ParticleSystem particle in particleSystems)
        {
            var collision = particle.collision;
            collision.bounce = bounce;
        }
    }

    public int getFireRate()
    {
        var emission = particleSystems[0].emission;
        return (int) emission.rateOverTime.constant;
    }

    public float getBulletSpeed()
    {
        var mainModule = particleSystems[0].main;
        return mainModule.startSpeed.constant;
    }

    public float getSize()
    {
        var mainModule = particleSystems[0].main;
        return mainModule.startSize.constant;
    }

    public int getBounce()
    {
        var collision = particleSystems[0].collision;
        return (int) collision.bounce.constant;
    }
}