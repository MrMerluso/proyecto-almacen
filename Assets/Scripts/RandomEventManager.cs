using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{

    private FirstPersonController Player;
    private CameraShake cameraShake;
    private PostProcessing postProcessing;

    public AudioSource fatigueSound;

    
    [SerializeField]
    private GameObject fatigueText;
    [SerializeField]
    private GameObject colorBlindText;

    public float slowDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // obtener el controlador de movimiento del jugador
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        //obtener el script de movimiento de camara
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        // obetener post procesado de la camara
        postProcessing = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessing>();
        //condici?n para que empiece a generar ordenes (m?s adelante tiene que ser en el per?odo de recreos)
        StartGenerateOrders();
    }

    private void StartGenerateOrders()
    {
        StartCoroutine(GenerateEvent());
    }


    private IEnumerator GenerateEvent()
    {
        //condici?n para que empiece a generar ordenes (m?s adelante tiene que ser en el per?odo de recreos)
        while (true)
        {
            yield return new WaitForSeconds(20f); //cada x cantidad de segundos
            Debug.Log("evento");

            float randomChance = Random.Range(0f, 1f);
            Debug.Log(randomChance);

            if (randomChance < 0.15f){
                Debug.Log("TERREMOTO!");
                cameraShake.start = true;
            }
            else if (randomChance < 0.35f)
            {
                Debug.Log("Fatiga");
                StartCoroutine(SlowPlayer());
            }
            else if (randomChance < 0.55f)
            {
                Debug.Log("Daltonismo");
                StartCoroutine(Grayscale());
            }

            //ver como vincular la orden a un producto (hamburguesa) con OrderItem.cs
        }
    }

    private IEnumerator SlowPlayer()
    {
        float initialPlayerSpeed = Player.walkSpeed;
        float elapsedTime = 0f;

        fatigueSound.Play();

        fatigueText.SetActive(true);

        while (elapsedTime < slowDuration)
        {
            elapsedTime += Time.deltaTime;
            Player.walkSpeed = 2f;
            yield return null;
        }

        fatigueText.SetActive(false);
        Player.walkSpeed = initialPlayerSpeed;
    }

    private IEnumerator Grayscale()
    {
        postProcessing.grayscale = true;
        colorBlindText.SetActive(true);

        yield return new WaitForSeconds(8f);

        colorBlindText.SetActive(false);
        postProcessing.grayscale = false;
    }

}
