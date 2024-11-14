using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    public GameObject CenaGameOver;

    public void IniciarGameOver()
    {
        CenaGameOver.SetActive(true);
    }

    public void ChamarCena()
    {
        SceneManager.LoadScene(1);
    }

    public void ChamarCenaNome()
    {
        SceneManager.LoadScene("Fase1");
    }


    public void ReiniciarFase(int numeroFase)
    {
        SceneManager.LoadScene(numeroFase);
    }

}
