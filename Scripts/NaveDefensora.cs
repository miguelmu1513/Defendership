using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveDefensora : MonoBehaviour
{
    public AudioClip SonidoDisparo; // Clip de sonido para el disparo
    private AudioSource audioSource; // Referencia al componente AudioSource
    public GameObject proyectilPrefab;
    public Transform PuntoDeDisparo; // Asegúrate de que este campo sea de tipo Transform
    public float velocidad = 5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Asigna el AudioSource adjunto a la nave
    }

    void Update()
    {
        // Movimiento de la nave defensora
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * movimientoHorizontal * velocidad * Time.deltaTime);

        // Disparo del proyectil
        if (Input.GetButtonDown("Fire1")) // Configura el botón de disparo en los Input Settings
        {
            Disparar();
        }
    }

    public void Disparar()
    {
        if (PuntoDeDisparo != null && proyectilPrefab != null)
        {
            Instantiate(proyectilPrefab, PuntoDeDisparo.position, PuntoDeDisparo.rotation);

            if (SonidoDisparo != null && audioSource != null)
            {
                audioSource.PlayOneShot(SonidoDisparo); // Reproduce el sonido de disparo
            }
            else
            {
                Debug.LogWarning("Sonido de disparo no asignado o AudioSource no encontrado.");
            }
        }
        else
        {
            Debug.LogError("PuntoDeDisparo o ProyectilPrefab no están asignados.");
        }
    }
}