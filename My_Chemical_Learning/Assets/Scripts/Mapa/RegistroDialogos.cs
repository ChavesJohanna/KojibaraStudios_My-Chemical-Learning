
using System.Collections.Generic;

public static class RegistroDialogos
{
    // Esto es para que el audio del dialogo solo se reproduzca una vez por globo de texto
    // Tiene en cuenta el cambio de escenas, por ej. entre nivel 1 y la mesa de trabajo y viceversa para evitar repetir el audio
    private static HashSet<string> dialogosReproducidos = new HashSet<string>();

    public static bool YaSeReprodujo(string id)
    {
        return dialogosReproducidos.Contains(id);
    }

    public static void Registrar(string id)
    {
        dialogosReproducidos.Add(id);
    }

    public static void Limpiar()
    {
        dialogosReproducidos.Clear();
    }
}
