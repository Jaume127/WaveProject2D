using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Time Stats")]
    [SerializeField] TMP_Text timerText; //Referencia al texto del tiempo en la UI
    [SerializeField] bool isCountdown; //Bool que determina si el tiempo se cuenta hacia atrás (true) o delante (false)
    float timeElapsed; //Variable que almacena el paso del tiempo (segundos)
    [SerializeField] float timeCountdown; //Variable que determina cuanto tiempo queremos contar hacia atrás (si el timer está en cuenta atrás)

    //Variables para definir la fragmentación del tiempo en minutos, segundos, centésimas...
    int minutes;
    int seconds;
    int cents;


    void Update()
    {
        if (!isCountdown)
        {
            //Llamada la método que cuenta el tiempo hacia delante
            TimerUp();
        }
        else
        {
            //Llamada al método que cuenta el tiempo hacia atrás
            TimerDown();
            if (timeCountdown <= 0)
            {
                timeCountdown = 0;
                GameManager.Instance.currentGameState = GameManager.GameStatus.gameOver;
            }
        }
    }

    void TimerUp()
    {
        timeElapsed += Time.deltaTime; //Suma al almacén del tiempo, el tiempo constante del juego
        minutes = (int) (timeElapsed / 60); //Casteo de int: Coge el valor de un float y lo redondea (1.9 = 1)
        seconds = (int) (timeElapsed - minutes * 60);
        cents = (int)((timeElapsed - (int)timeElapsed) * 100);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);
    }

    void TimerDown()
    {
        timeCountdown -= Time.deltaTime;
        minutes = (int)(timeCountdown / 60);
        seconds = (int)(timeCountdown - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
