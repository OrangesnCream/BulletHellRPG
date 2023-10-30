using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMaker : MonoBehaviour
{
    public int number_of_columns;
    public Color color;
    public Material material;
    private float spin_speed;
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
            system = go.AddComponent<LineRenderer>();

            system.startColor = color;
            system.enabled = false;
            system.useWorldSpace = true;
            system.material = material;
            system.SetPosition(0, transform.position);
            system.SetPosition(1, new Vector3(Mathf.Cos(((angle * i * Mathf.PI) / 180)), Mathf.Sin((angle * i * Mathf.PI) / 180), 0) * 5000);
        }
    }

    public void setSpinSpeed(float spinspeed) { this.spin_speed = spinspeed; }
    public float getSpinSpeed() { return this.spin_speed; }

    public int getColumns() { return this.number_of_columns; }

    public float getDegrees() { return this.degrees; }
}
