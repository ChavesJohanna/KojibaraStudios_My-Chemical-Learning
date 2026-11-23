using UnityEngine;

public class ParallaxMovement : MonoBehaviour
{
    Transform cam; //Main Camera
    Camera camComp;
    Vector3 camStartPos;
    float distance;

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;
    Vector2[] baseTiling;   // tiling original de cada material
    float[] baseScaleX;     // scale X original de cada plano
    float farthestBack;
    float ultimoAspect;

    [Range(0.01f, 1f)]
    public float parallaxSpeed;

    [Tooltip("Margen extra para evitar bordes en pantallas muy alargadas")]
    public float margin = 1.3f;

    void Start()
    {
        camComp = Camera.main;
        cam = camComp.transform;
        camStartPos = cam.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];
        baseTiling = new Vector2[backCount];
        baseScaleX = new float[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
            baseTiling[i] = mat[i].GetTextureScale("_MainTex");
            baseScaleX[i] = backgrounds[i].transform.localScale.x;
        }

        BackSpeedCalculate(backCount);
        AjustarAnchoAPantalla();
        ultimoAspect = camComp.aspect;
    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++) //find the farthest background
        {
            float d = backgrounds[i].transform.position.z - cam.position.z;
            if (d > farthestBack) farthestBack = d;
        }

        for (int i = 0; i < backCount; i++) //set the speed of background
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    // Agranda cada plano 
    void AjustarAnchoAPantalla()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float alto, ancho;

            if (camComp.orthographic)
            {
                alto = camComp.orthographicSize * 2f;
            }
            else
            {
                float dist = Mathf.Abs(backgrounds[i].transform.position.z - cam.position.z);
                alto = 2f * dist * Mathf.Tan(camComp.fieldOfView * 0.5f * Mathf.Deg2Rad);
            }

            ancho = alto * camComp.aspect * margin;

            
            float escalaPadre = transform.lossyScale.x;
            float scaleNecesario = ancho / (10f * escalaPadre);

            Vector3 s = backgrounds[i].transform.localScale;
            s.x = Mathf.Max(baseScaleX[i], scaleNecesario);
            backgrounds[i].transform.localScale = s;

            // Mantiene la textura sin estirarse
            float factor = s.x / baseScaleX[i];
            mat[i].SetTextureScale("_MainTex",
                new Vector2(baseTiling[i].x * factor, baseTiling[i].y));
        }
    }

    private void LateUpdate()
    {
        // Recalcula si cambia el aspect 
        if (Mathf.Abs(camComp.aspect - ultimoAspect) > 0.01f)
        {
            ultimoAspect = camComp.aspect;
            AjustarAnchoAPantalla();
        }

        distance = cam.position.x - camStartPos.x;
        transform.position = new Vector3(cam.position.x, cam.position.y, 0.27f);

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}