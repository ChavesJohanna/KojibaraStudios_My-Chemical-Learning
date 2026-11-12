using UnityEngine;

public class ControladorJefe : MonoBehaviour//se encuentra el el objeto llamado "Jefe"
{
    private AtaqueGolpe ataqueGolpe;


    private void Start()
    {
        ataqueGolpe = GetComponentInChildren<AtaqueGolpe>();

        InvokeRepeating(nameof(EjecutarAtaque), 2f, 3f);
    }

    private void EjecutarAtaque()
    {
        ataqueGolpe.Atacar();
    }
}
