using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private CARD carta1 = null;
    private CARD carta2 = null;

    private void Awake()
    {
        Instance = this;
    }

    public void CartaSeleccionada(CARD carta)
    {
        if (carta1 == null)
        {
            carta1 = carta;
        }
        else if (carta2 == null && carta != carta1)
        {
            carta2 = carta;
            StartCoroutine(VerificarMatch());
        }
    }

    private IEnumerator VerificarMatch()
    {
        yield return new WaitForSeconds(0.5f);

        if (carta1.cardID == carta2.cardID)
        {
            // Animación de unión
            yield return StartCoroutine(AnimarMatch(carta1, carta2));

            // Esperar 3 segundos antes de destruir
            yield return new WaitForSeconds(3f);

            // Destruir las cartas
            Destroy(carta1.gameObject);
            Destroy(carta2.gameObject);
        }
        else
        {
            carta1.Ocultar();
            carta2.Ocultar();
        }

        carta1 = null;
        carta2 = null;
    }

    private IEnumerator AnimarMatch(CARD c1, CARD c2)
    {
        Vector3 posFinal = (c1.transform.position + c2.transform.position) / 2f;

        float duracion = 0.3f;
        float tiempo = 0f;

        Vector3 start1 = c1.transform.position;
        Vector3 start2 = c2.transform.position;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / duracion;

            c1.transform.position = Vector3.Lerp(start1, posFinal, t);
            c2.transform.position = Vector3.Lerp(start2, posFinal, t);

            yield return null;
        }

        float separacionMinima = 0.3f;

        c1.transform.position = posFinal + new Vector3(0, -separacionMinima / 2f, 0);
        c2.transform.position = posFinal + new Vector3(0, separacionMinima / 2f, 0);
    }
}