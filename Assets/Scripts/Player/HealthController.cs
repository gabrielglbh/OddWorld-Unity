using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Clase para manejar y administrar los corazones en la UI y
// lanzar los eventos necesarios (Canvas > HeartContainers)
public class HealthController : MonoBehaviour
{

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public FloatValue containers;
    public FloatValue playerHealth;

    void Start()
    {
        for (int x = 0; x < containers.initialValue; x++) 
        {
            hearts[x].gameObject.SetActive(true);
            hearts[x].sprite = fullHeart;
        }
    }

    // Esta función está incluida en la lista de eventos de SignalListener
    // en el HealthContainer. La señal que se está escuchando es 
    // PlayerHealthSignal, el cual está adherido en el PlayerController y 
    // la cual notifica cuando el jugador ha sido dañado por un enemigo en DealDamage(). 
    // Cuando esta notifique, esta función se ejecutará.
    public void UpdateUIOnHit() 
    {
        float tempHealth = playerHealth.RuntimeValue / 2;
        for (int x = 0; x < containers.initialValue; x++) 
        {
            if (x <= tempHealth - 1)
            {
                hearts[x].sprite = fullHeart;
            } 
            else if (x >= tempHealth) 
            {
                hearts[x].sprite = emptyHeart;
            }
            else {
                hearts[x].sprite = halfHeart;
            }
        }
    }

    // Función lanzada con la notificación de la señal PlayerHealthGained
    // Actualiza la UI con un nuevo contenedor
    public void UpdateUIOnGain()
    {
        float tempHealth = playerHealth.RuntimeValue / 2;
        playerHealth.RuntimeValue += 1;
        // TODO: Manage health gain
    }
}
