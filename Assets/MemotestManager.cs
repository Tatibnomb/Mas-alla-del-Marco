using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MemotestManager : MonoBehaviour
{
    public GameObject fichaPrefab;      // ANTES: cardPrefab
    public Transform gridPadre;

    public List<Sprite> imagenesCuadros;
    public List<string> nombresCuadros;

    private Ficha primeraSeleccion = null;
    private Ficha segundaSeleccion = null;

    private List<int> indicesBarajados;

    void Start()
    {
        GenerarMemotest();
    }

    void GenerarMemotest()
    {
        indicesBarajados = new List<int>();
        int total = imagenesCuadros.Count;

        // duplicar pares
        for (int i = 0; i < total * 2; i++)
        {
            indicesBarajados.Add(i % total);
        }

        // barajar
        for (int i = 0; i < indicesBarajados.Count; i++)
        {
            int r = Random.Range(0, indicesBarajados.Count);
            (indicesBarajados[i], indicesBarajados[r]) = (indicesBarajados[r], indicesBarajados[i]);
        }

        // instanciar fichas
        for (int i = 0; i < indicesBarajados.Count; i++)
        {
            int id = indicesBarajados[i];

            bool esTexto = (i % 2 == 0);

            GameObject nueva = Instantiate(fichaPrefab, gridPadre);

            Ficha ficha = nueva.GetComponent<Ficha>();

            if (esTexto)
            {
                ficha.Setup(id, null, nombresCuadros[id], true);
            }
            else
            {
                ficha.Setup(id, imagenesCuadros[id], nombresCuadros[id], false);
            }
        }
    }

    // 💥 ESTE MÉTODO YA FUNCIONA
    public void FichaSeleccionada(Ficha ficha)
    {
        if (primeraSeleccion == null)
        {
            primeraSeleccion = ficha;
            return;
        }

        if (segundaSeleccion == null && ficha != primeraSeleccion)
        {
            segundaSeleccion = ficha;
            Verificar();
        }
    }

    void Verificar()
    {
        if (primeraSeleccion.pairID == segundaSeleccion.pairID)
        {
            primeraSeleccion.Correct();
            segundaSeleccion.Correct();
        }
        else
        {
            // Si querés animación de "vuelta", ponela aquí
        }

        primeraSeleccion = null;
        segundaSeleccion = null;
    }
}