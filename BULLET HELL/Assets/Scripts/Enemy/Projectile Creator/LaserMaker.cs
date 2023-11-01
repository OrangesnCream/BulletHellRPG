using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserMaker : MonoBehaviour
{
    public int number_of_columns;
    public Color color;
    public Material material;
    public float spin_speed;
    private float time;
    public LayerMask collision_layers;
    private float angle;
    public int degrees;

    public LineRenderer system;

    private void Awake()
    {
        Summon();
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        this.transform.rotation = Quaternion.Euler(0, 0, time * spin_speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Summon()
    {
        angle = degrees / number_of_columns;

        for (int i = 0; i < number_of_columns; i++)
        {
            var go = new GameObject("Laser_" + i);
            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            go.layer = LayerMask.NameToLayer("Enemy_Bullet");
            go.tag = transform.tag;

            system = go.AddComponent<LineRenderer>();

            system.startColor = color;
            system.endColor = color;
            system.enabled = true;
            system.useWorldSpace = true;
            system.material = material;
        }
    }

    public void setSpinSpeed(float spinspeed) { this.spin_speed = spinspeed; }
    public float getSpinSpeed() { return this.spin_speed; }

    public int getColumns() { return this.number_of_columns; }

    public float getDegrees() { return this.degrees; }

    public float getAngle() { return this.angle; }

    public int getLayerMask() { return this.collision_layers; }
}
