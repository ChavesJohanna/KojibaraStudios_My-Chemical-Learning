using UnityEngine;

public class Pirito : MonoBehaviour //el script se encuentra en el enemigo con el mismo nombre
{
    private SpriteRenderer sprite; //se obtiene para voltear al cambiar de direccion
    private Rigidbody2D rb;

    private float velocidad = 1f;
    private float distancia = 5f; //cantidad de ditancia que se movera

    private Vector2 posicionInicial;
    private int direccion = 1;

    private float vida = 10f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        posicionInicial = transform.position;
    }

    private void FixedUpdate()
    {
        float nuevaX = rb.position.x + direccion * velocidad * Time.fixedDeltaTime; //mueve al enemigo de forma lateral
        rb.MovePosition(new Vector2(nuevaX, rb.position.y));


        if (nuevaX >= posicionInicial.x + distancia) //cambia de direccion
        {
            direccion = -1;
        }
            
        else if (nuevaX <= posicionInicial.x)
        {
            direccion = 1;
        }

        sprite.flipX = direccion < 0; //si la direccion es negativa se voltea el sprite

    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        
        if (otro.gameObject.CompareTag("Agua"))
        {
            vida -= 5f;

            if(vida <= 0) //si la vida es cero se desactiva el objeto
                gameObject.SetActive(false);
        }
    }
}
