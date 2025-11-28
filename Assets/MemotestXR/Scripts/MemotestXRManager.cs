using System.Collections.Generic;
using UnityEngine;

public class MemotestXRManager : MonoBehaviour
{
    [System.Serializable]
    public class CuadroData
    {
        public string nombre;
        public Sprite imagen;
    }

    public List<CuadroData> cuadros;
    public TarjetaXR tarjetaPrefab;
    public Transform grid;

    private List<TarjetaXR> seleccionadas = new List<TarjetaXR>();

    void Start()
    {
        GenerarTarjetas();
    }

    void GenerarTarjetas()
    {
        List<TarjetaXR> listaTarjetas = new List<TarjetaXR>();

        foreach (var c in cuadros)
        {
            var t1 = Instantiate(tarjetaPrefab, grid);
            t1.Configurar(c.imagen, "", c.nombre);
            listaTarjetas.Add(t1);

            var t2 = Instantiate(tarjetaPrefab, grid);
            t2.Configurar(null, c.nombre, c.nombre);
            listaTarjetas.Add(t2);
        }

        // Mezclar
        for (int i = 0; i < listaTarjetas.Count; i++)
        {
            int r = Random.Range(0, listaTarjetas.Count);
            listaTarjetas[i].transform.SetSiblingIndex(r);
        }
    }

    public void Seleccionar(TarjetaXR t)
    {
        if (seleccionadas.Count == 2)
            return;

        seleccionadas.Add(t);

        bool esImagen = t.imagenUI.sprite != null;
        t.Revelar(esImagen);

        if (seleccionadas.Count == 2)
            Invoke(nameof(ChequearPareja), 1f);
    }

    void ChequearPareja()
    {
        var a = seleccionadas[0];
        var b = seleccionadas[1];

        if (a.id == b.id)
        {
            a.Desactivar();
            b.Desactivar();
        }
        else
        {
            a.Ocultar();
            b.Ocultar();
        }

        seleccionadas.Clear();
    }
}