using UnityEngine;

public class Oxidee : EnemigoMovil
{
    protected override void Start()
    {
        base.Start();

        vida = 20f;
        velocidad = 0.5f;
    }
}