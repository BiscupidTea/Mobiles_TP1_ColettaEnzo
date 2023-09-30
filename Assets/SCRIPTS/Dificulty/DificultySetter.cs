using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DificultySetter : MonoBehaviour
{
    [SerializeField] private Transform[] posicionBolsas;

    [SerializeField] private Transform[] posicionObstaculosFacil;
    [SerializeField] private Transform[] posicionObstaculosNormal;
    [SerializeField] private Transform[] posicionObstaculosDificil;

    [SerializeField] private GameObject bolsaPrefab;
    [SerializeField] private GameObject obstaculoPrefab;
    [SerializeField] private GameObject ParedPrefab;

    [SerializeField] private List<GameObject> bolsaList;
    [SerializeField] private List<GameObject> Obstaculos;

    public void StartNewRace(int nivelJuego)
    {
        for (int i = 0; i < posicionBolsas.Length; i++)
        {
            GameObject bolsa = Instantiate(bolsaPrefab, posicionBolsas[i].transform.position, posicionBolsas[i].transform.rotation, gameObject.transform);
            bolsa.SetActive(true);
            bolsaList.Add(bolsa);
        }

        if (nivelJuego >= 1)
        {
            for (int i = 0; i < posicionObstaculosFacil.Length; i++)
            {
                GameObject obstacle = Instantiate(obstaculoPrefab, posicionObstaculosFacil[i].transform.position, posicionObstaculosFacil[0].transform.rotation, gameObject.transform);
                obstacle.SetActive(true);
                Obstaculos.Add(obstacle);
            }
        }
        
        if (nivelJuego >= 2)
        {
            for (int i = 0; i < posicionObstaculosNormal.Length; i++)
            {
                GameObject obstacle = Instantiate(obstaculoPrefab, posicionObstaculosNormal[i].transform.position, posicionObstaculosNormal[0].transform.rotation, gameObject.transform);
                obstacle.SetActive(true);
                Obstaculos.Add(obstacle);
            }
        }

        if (nivelJuego == 3)
        {
            for (int i = 0; i < posicionObstaculosDificil.Length; i++)
            {
                GameObject obstacle = Instantiate(ParedPrefab, posicionObstaculosDificil[i].transform.position, posicionObstaculosDificil[0].transform.rotation, gameObject.transform);
                obstacle.SetActive(true);
                Obstaculos.Add(obstacle);
            }
        }
    }
}