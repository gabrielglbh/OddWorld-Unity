using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour
{
    public GameObject prefabEnemy;
    public FloatValue currentEnemies;
    public FloatValue currentPoints;
    public BoolValue isInTrial;
    public Text elapsedTime;
    public Text points;
    public Transform[] spawnPoints;
    private float spawnDelay = 2.25f; 
    private float maxEnemies = 12f;
    public CustomSignal trialEnter;
    public CustomSignal trialExit;

    public Text dialogText;
    public string dialog;

    void Start()
    {
        elapsedTime.text = "0";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("TrialEnter") && other.isTrigger)
        {
            if (!isInTrial.RuntimeValue)
            {
                StartTrial();
            }
        }
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("TrialExit") && other.isTrigger)
        {
            if (isInTrial.RuntimeValue)
            {
                EndTrial();
            }
        }
    }

    public void StartTrial()
    {
        StartCoroutine(ShowDialogBox());
        StartCoroutine(AddEnemy());
        StartCoroutine(CreateTimer());
        isInTrial.RuntimeValue = true;
        trialEnter.Notify();
    }

    public void EndTrial()
    {
        StartCoroutine(ShowDialogBox());
        isInTrial.RuntimeValue = false;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
            currentEnemies.RuntimeValue -= 1;
        }
        trialExit.Notify();
    }

    private IEnumerator AddEnemy() 
    {
        while (true) 
        {
            // No se hace spawn de enemigos hasta que se mate a alguno
            if (currentEnemies.RuntimeValue < maxEnemies) 
            {
                int rnd = UnityEngine.Random.Range(0, spawnPoints.Length);
                Instantiate(prefabEnemy, spawnPoints[rnd].position, Quaternion.identity);
                currentEnemies.RuntimeValue += 1;
            }
            yield return new WaitForSeconds(spawnDelay);
            // Salir de la rutina si isInTrial es false
            if (!isInTrial.RuntimeValue) yield break;
        }
    }

    private IEnumerator CreateTimer() 
    {
        int currentTime = 0;
        while(true)
        {
            currentTime += 1;
            elapsedTime.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            // Salir de la rutina si isInTrial es false
            if (!isInTrial.RuntimeValue) yield break;
        }
    }


    // Pinta SceneDialog con los puntos y tiempo transcurrido en la Prueba
    // Despu??s, hace reset de esos par??metros
    private IEnumerator ShowDialogBox()
    {
        dialogText.gameObject.SetActive(true);
        if (this.gameObject.CompareTag("TrialEnter"))
        {
            dialogText.text = dialog;
            yield return new WaitForSeconds(3f);
        }
        else if (this.gameObject.CompareTag("TrialExit"))
        {
            dialogText.text = dialog +
                "\n\nTiempo Total (s): " + elapsedTime.text +
                "\n\nPuntos Totales: " + currentPoints.RuntimeValue;
            yield return new WaitForSeconds(3f);
            elapsedTime.text = "0";
            points.text = "000";
            currentPoints.RuntimeValue = 0f;
        }
        dialogText.gameObject.SetActive(false);
    }
}
