using UnityEngine;

public static class GuardarNivel
{
    private static string nivelAnterior;

    public static void GuardarNivelActual(string nivel)
    {
        nivelAnterior = nivel;
    }

    public static string ObtenerNivelAnterior()
    {
        return nivelAnterior;
    }
}