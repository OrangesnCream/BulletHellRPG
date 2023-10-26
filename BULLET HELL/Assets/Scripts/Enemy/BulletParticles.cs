using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticles : MonoBehaviour
{
    public int number_of_columns;
    private float bullet_speed;
    public Sprite sprite;
    public Color color;
    public float lifetime;
    private int firerate;
    private float size;
    private float angle;
    public Material material;
    private float spin_speed;
    private float time;
    public LayerMask collision_layers;
    public int degrees;

    public ParticleSystem system;

    private void Awake()
    {
        Summon();
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        this.transform.rotation = Quaternion.Euler(0, 0, time * spin_speed);
    }

    void Summon()
    {
        angle = degrees / number_of_columns;

        for (int i = 0; i < number_of_columns; i++)
        {
            // A simple particle material with no texture.
            Material particleMaterial = material;

            // Create a Particle System.
            var go = new GameObject("Particle_System_" + i);
            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            go.layer = LayerMask.NameToLayer("Bullet");
            go.tag = "Enemy_Bullet";

            var mainModule = system.main;
            mainModule.startSpeed = bullet_speed;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;
            mainModule.startColor = color;
            mainModule.startSize = size;
            mainModule.startLifetime = lifetime;

            var emission = system.emission;
            emission.enabled = true;
            emission.rateOverTime = firerate;

            var form = system.shape;
            form.enabled = true;
            form.shapeType = ParticleSystemShapeType.Sprite;
            form.sprite = null;

            var text = system.textureSheetAnimation;
            text.enabled = true;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(sprite);

            var collision = system.collision;
            collision.enabled = true;
            collision.type = ParticleSystemCollisionType.World;
            collision.bounce = 0;
            collision.lifetimeLoss = 1;
            collision.mode = ParticleSystemCollisionMode.Collision2D;
            collision.collidesWith = collision_layers;
            collision.sendCollisionMessages = true;

            var velocity = system.velocityOverLifetime;
            velocity.enabled = true;
            
        }
    }
    public void setSpinSpeed(float spinspeed) { this.spin_speed = spinspeed; }
    public float getSpinSpeed() { return this.spin_speed; }

    public int getColumns() { return this.number_of_columns; }

    public float getDegrees() { return this.degrees; }
}
