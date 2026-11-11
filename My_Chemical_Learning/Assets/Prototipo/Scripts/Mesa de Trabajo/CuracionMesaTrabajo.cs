using UnityEngine;

public class CuracionMesaTrabajo : MonoBehaviour
{
    public static bool DebeCurar { get; private set; }

    public static void ActivarCuracion()
    {
        DebeCurar = true;
    }

    public static void ReiniciarCuracion()
    {
        DebeCurar = false;
    }
}