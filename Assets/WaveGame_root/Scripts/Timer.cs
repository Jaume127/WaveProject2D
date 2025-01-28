using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Time Stats")]
    [SerializeField] TMP_Text timerText; //Referencia al texto del tiempo en la UI
    [SerializeField] bool isCountdown; //Bool que determina si el tiempo se cuenta hacia atr�s (true) o delante (false)
    float timeElapsed; //Variable que almacena el paso del tiempo (segundos)
    [SerializeField] float timeCountdown; //Variable que determina cuanto tiempo queremos contar hacia atr�s (si el timer est� en cuenta atr�s)

    //Variables para definir la fragmentaci�n del tiempo en minutos, segundos, cent�simas...
    int minutes;
    int seconds;
    int cents;


    void Update()
    {
        if (!isCountdown)
        {
            //Llamada la m�todo que cuenta el tiempo hacia delante
            TimerUp();
        }
        else
        {
            //Llamada al m�todo que cuenta el tiempo hacia atr�s
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
        timeElapsed += Time.deltaTime; //Suma al almac�n del tiempo, el tiempo constante del juego
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
