using System.Collections;
using UnityEngine;

public class DañarJefe : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator anim;

    private float vidaMaxima = 100f;

    private float vidaActual;

    private Color colorDaño = new Color(0.8f, 0.2f, 0.2f); //un color rogizo para el daño

    float porcentajeDanio;

    private bool derrotado = false;

    private SpriteRenderer mDer;
    private SpriteRenderer mIzq;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        vidaActual = vidaMaxima;

        mDer = transform.Find("ManoDer").GetComponent<SpriteRenderer>();
        mIzq = transform.Find("ManoIzq").GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Agua")) //coloco al jugador como prueba
        {
            vidaActual -= 5f;

            vidaActual = Mathf.Max(vidaActual, 0f); //evita que la vida se negativa

            porcentajeDanio = 1f - (vidaActual / vidaMaxima); //establece un porcentaje segun la vida

            CambiarColor(sprite);//va poniendo rojo a cavana en lo que pierde vida
            CambiarColor(mDer);
            CambiarColor(mIzq);

            Debug.Log("Vida del jefe: " + vidaActual);

            if (vidaActual <= 0f) //una vez se queda sin vida inicia la animacion y luego se desactiva
            {
                StartCoroutine(Delay());
            }
        }
    }

    private IEnumerator Delay()
    {
        sprite.color = Color.white;

        anim.SetBool("FueDerrotado", true);

        derrotado = true;

        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);


    }
    private void CambiarColor(SpriteRenderer sprite)
    {
        sprite.color = Color.Lerp(Color.white, colorDaño, porcentajeDanio);
    }

    public bool Derrotado()
    {
        return this.derrotado;
    }
}
