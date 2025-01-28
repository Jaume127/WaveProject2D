using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Inicio de la declaración de Singleton

    //Primero, se declara la "Fortaleza de datos" privada
    private static GameManager instance;
    //Segundo, se declara una llave pública que puede acceder a la fortaleza
    //Esta llave puede ser llamada por otros scripts SIN REFERENCIA
    public static GameManager Instance
    {
        get
        {
            if (instance != null) Debug.Log("There is a GameManager already");
            return instance;
        }
    }

    //Fin del singleton
    //A partir de aquí se declaran todos los datos de la fortaleza en public
    public int currentPoints;
    public float currentLife;

    //Definición de ENUM: Variables con valor inventado que queramos
    public enum GameStatus {gameOver, gamePaused, gameRunning}; //ENUM define el tipo de variable {posibles valores que puede tener}
    public GameStatus currentGameState = GameStatus.gameRunning;




    private void Awake()
    {
        if (instance ==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}
