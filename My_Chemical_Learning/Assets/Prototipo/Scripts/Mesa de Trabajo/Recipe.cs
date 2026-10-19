using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Chemistry/Recipe")]
public class Recipe : ScriptableObject
{
    [Tooltip("Elementos necesarios, repetidos según la cantidad. Ej: Agua = [Hidrogeno, Hidrogeno, Oxigeno]")]
    public List<ChemElementType> ingredientes;

    public string nombreResultado; // ej: "Agua (H2O)"

    [Tooltip("Nombre que espera DesbloqueoElemento Ejem Agua, Sal, Acido")]
    public string idDesbloqueo;    // NUEVO

    public GameObject prefabResultado; // el objeto que aparece si la combinación es correcta

    // Compara si una lista de elementos (sin importar el orden) coincide con esta receta
    public bool Coincide(List<ChemElementType> elementosActuales)
    {
        if (elementosActuales.Count != ingredientes.Count) return false;

        List<ChemElementType> copiaIngredientes = new List<ChemElementType>(ingredientes);

        foreach (var elemento in elementosActuales)
        {
            if (!copiaIngredientes.Remove(elemento))
            {
                return false; 
            }
        }

        return copiaIngredientes.Count == 0;
    }
}