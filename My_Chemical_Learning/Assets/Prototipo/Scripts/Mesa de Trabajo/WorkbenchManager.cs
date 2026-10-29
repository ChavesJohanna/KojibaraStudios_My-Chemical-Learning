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

    // Se llama una vez cuando el jugador suelta un elemento.
    public void EvaluarSoltado(
        ChemElement soltado,
        List<ChemElement> superpuestos)
    {
        if (soltado == null || superpuestos == null ||
            superpuestos.Count == 0)
            return;

        List<ChemElement> involucrados = new List<ChemElement>(superpuestos)
        {
            soltado
        };

        List<ChemElementType> tipos =
            involucrados.Select(e => e.type).ToList();

        foreach (Recipe receta in recetas)
        {
            if (receta != null && receta.Coincide(tipos))
            {
                StartCoroutine(EsperarYCombinar(receta, involucrados));
                return;
            }
        }

        if (ExisteRecetaCompatible(tipos))
            return;

        // Si no hay una combinación posible, separa los ingredientes.
        Draggable draggableSoltado = soltado.GetComponent<Draggable>();

        if (draggableSoltado == null)
            return;

        foreach (ChemElement otro in superpuestos)
        {
            if (otro == null)
                continue;

            float distancia =
                ObtenerRadio(soltado) + ObtenerRadio(otro) +
                margenSeparacion;

            draggableSoltado.EmpujarFuera(
                otro.transform.position,
                distancia
            );
        }
    }

    private IEnumerator EsperarYCombinar(
        Recipe receta,
        List<ChemElement> involucrados)
    {
        yield return new WaitForSeconds(tiempoEsperaCombinacion);

        // Cancela la combinación si algún ingrediente fue destruido.
        if (involucrados.Any(e => e == null))
            yield break;

        Vector3 posicion = involucrados[0].transform.position;

        foreach (ChemElement elemento in involucrados)
        {
            Destroy(elemento.gameObject);
        }

        if (receta.prefabResultado != null)
        {
            Instantiate(
                receta.prefabResultado,
                posicion,
                Quaternion.identity
            );
        }

        // Guarda el identificador correcto del elemento fabricado.
        if (DesbloqueoElementos.Instance != null)
        {
            DesbloqueoElementos.Instance.AsignarElementoInventario(
                receta.idDesbloqueo
            );
        }
    }

    // Comprueba si los ingredientes todavía pueden formar alguna receta.
    private bool ExisteRecetaCompatible(List<ChemElementType> tipos)
    {
        foreach (Recipe receta in recetas)
        {
            if (receta == null)
                continue;

            List<ChemElementType> copia =
                new List<ChemElementType>(receta.ingredientes);

            bool esSubconjunto = true;

            foreach (ChemElementType tipo in tipos)
            {
                if (!copia.Remove(tipo))
                {
                    esSubconjunto = false;
                    break;
                }
            }

            if (esSubconjunto)
                return true;
        }

        return false;
    }

    private float ObtenerRadio(ChemElement elemento)
    {
        CircleCollider2D circulo =
            elemento.GetComponent<CircleCollider2D>();

        if (circulo != null)
        {
            return circulo.radius * Mathf.Max(
                elemento.transform.lossyScale.x,
                elemento.transform.lossyScale.y
            );
        }

        return 1f;
    }
}