using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorkbenchManager : MonoBehaviour
{
    public List<Recipe> recetas;

    [Tooltip("Margen extra de separación al rechazar una combinación")]
    public float margenSeparacion = 0.2f;

    [Tooltip("Segundos de espera antes de confirmar una combinación correcta")]
    public float tiempoEsperaCombinacion = 2f;

    // Se llama una sola vez, cuando el jugador suelta un elemento
    public void EvaluarSoltado(ChemElement soltado, List<ChemElement> superpuestos)
    {
        if (superpuestos.Count == 0) return; // no quedó sobre nada, no hay nada que evaluar

        List<ChemElement> involucrados = new List<ChemElement>(superpuestos) { soltado };
        List<ChemElementType> tipos = involucrados.Select(e => e.type).ToList();

        // 1) ¿Coincide exacto con alguna receta? -> cuenta regresiva y combina
        foreach (Recipe receta in recetas)
        {
            if (receta.Coincide(tipos))
            {
                StartCoroutine(EsperarYCombinar(receta, involucrados));
                return;
            }
        }

        // 2) ¿Todavía podría completarse con más elementos? -> dejarlo superpuesto, no hacer nada
        if (ExisteRecetaCompatible(tipos))
        {
            return;
        }

        // 3) Combinación imposible -> expulsar al que se soltó, fuera de los colliders de los demás
        Debug.LogWarning($"No se puede combinar: [{string.Join(" + ", tipos)}]");

        Draggable draggableSoltado = soltado.GetComponent<Draggable>();
        if (draggableSoltado == null) return;

        foreach (var otro in superpuestos)
        {
            float distancia = ObtenerRadio(soltado) + ObtenerRadio(otro) + margenSeparacion;
            draggableSoltado.EmpujarFuera(otro.transform.position, distancia);
        }
    }

    private IEnumerator EsperarYCombinar(Recipe receta, List<ChemElement> involucrados)
    {
        Debug.Log($"Se va a combinar en {tiempoEsperaCombinacion} segundos...");
        yield return new WaitForSeconds(tiempoEsperaCombinacion);

        // Si alguno de los elementos fue destruido o movido/arrastrado de nuevo en el medio tiempo, cancelar
        if (involucrados.Any(e => e == null)) yield break;

        Debug.Log($"Combinación correcta: {receta.nombreResultado}");

        Vector3 posicion = involucrados[0].transform.position;

        foreach (var elemento in involucrados)
        {
            Destroy(elemento.gameObject);
        }

        if (receta.prefabResultado != null)
        {
            Instantiate(receta.prefabResultado, posicion, Quaternion.identity);
        }

        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.AgregarElementoConseguido(receta.nombreResultado);
        }
        else
        {
            Debug.LogWarning("No hay InventoryManager en la escena, no se guardó el resultado.");
        }
    }

    // True si "tipos" es subconjunto (con cantidades) de alguna receta
    private bool ExisteRecetaCompatible(List<ChemElementType> tipos)
    {
        foreach (Recipe receta in recetas)
        {
            List<ChemElementType> copia = new List<ChemElementType>(receta.ingredientes);
            bool esSubconjunto = true;

            foreach (var tipo in tipos)
            {
                if (!copia.Remove(tipo))
                {
                    esSubconjunto = false;
                    break;
                }
            }

            if (esSubconjunto) return true;
        }

        return false;
    }

    private float ObtenerRadio(ChemElement elemento)
    {
        CircleCollider2D circulo = elemento.GetComponent<CircleCollider2D>();
        if (circulo != null)
        {
            return circulo.radius * Mathf.Max(elemento.transform.lossyScale.x, elemento.transform.lossyScale.y);
        }

        return 1f; // valor por defecto si no es CircleCollider2D
    }
}