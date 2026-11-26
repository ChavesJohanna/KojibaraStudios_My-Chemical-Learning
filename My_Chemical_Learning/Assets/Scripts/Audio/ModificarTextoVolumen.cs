using UnityEngine;

public static class ModificarTextoVolumen //servira para avisar a los textos de los volumenes para que muestran el texto segun el volumen
{
    private static bool volMusica = false;
    private static bool volEfectos = false;


    public static bool CambiandoVolMusica()
    {
        return volMusica = true;
    }

    public static bool CambiandoVolEfectos()
    {
        return volEfectos = true;
    }

    public static void VolumenDeterminado() //se encontrara en el boton que cierra el panel de opciones
    {
        volMusica = false;
        volEfectos = false;
    }

    public static string ValorDeVar() //namas lo uso para ver si se esta setiaando las variables correctamente
    {
        return $"El volMusica esta en: {volMusica}\n" +
               $"El volEfectos esta en: {volEfectos}";
    }
}
