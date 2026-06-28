using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorkbenchManager : MonoBehaviour
{
    public List<Recipe> recetas;

    // Elementos actualmente sobre la mesa (se registran/desregistran solos)
    private List<ChemElement> _elementosEnMesa = new List<ChemElement>();

    public void RegistrarElemento(ChemElement elemento)
    {
        if (!_elementosEnMesa.Contains(elemento))
        {
            _elementosEnMesa.Add(elemento);
        }

        IntentarCombinar();
    }

    public void DesregistrarElemento(ChemElement elemento)
    {
        _elementosEnMesa.Remove(elemento);
    }

    private void IntentarCombinar()
    {
        // Solo intenta combinar si hay 2 o más elementos juntos
        if (_elementosEnMesa.Count < 2) return;

        List<ChemElementType> tipos = _elementosEnMesa.Select(e => e.type).ToList();

        foreach (Recipe receta in recetas)
        {
            if (receta.Coincide(tipos))
            {
                CombinacionCorrecta(receta);
                return;
            }
        }

        // Si llegamos hasta acá y ya hay tantos elementos juntos como la receta más grande,
        // probablemente sea una combinación incorrecta
        int maxIngredientes = recetas.Count > 0 ? recetas.Max(r => r.ingredientes.Count) : 0;
        if (_elementosEnMesa.Count >= maxIngredientes && maxIngredientes > 0)
        {
            CombinacionIncorrecta();
        }
    }

    private void CombinacionCorrecta(Recipe receta)
    {
        Debug.Log($"Combinación correcta: {receta.nombreResultado}");

        Vector3 posicion = _elementosEnMesa[0].transform.position;

        foreach (var elemento in _elementosEnMesa.ToList())
        {
            Destroy(elemento.gameObject);
        }
        _elementosEnMesa.Clear();

        if (receta.prefabResultado != null)
        {
            Instantiate(receta.prefabResultado, posicion, Quaternion.identity);
        }

        InventoryManager.Instance.AgregarElementoConseguido(receta.nombreResultado);
    }

    private void CombinacionIncorrecta()
    {
        Debug.LogWarning("Combinación incorrecta, separando elementos.");

        foreach (var elemento in _elementosEnMesa)
        {
            Draggable draggable = elemento.GetComponent<Draggable>();
            if (draggable != null)
            {
                draggable.VolverAPosicionOriginal();
            }
        }

        _elementosEnMesa.Clear();
    }
}