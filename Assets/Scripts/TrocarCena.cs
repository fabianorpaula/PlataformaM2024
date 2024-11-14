using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    

    public void ChamarCena()
    {
        SceneManager.LoadScene(1);
    }

    public void ChamarCenaNome()
    {
        SceneManager.LoadScene("Fase1");
    }

}
