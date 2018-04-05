using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour {

    //clase que almacena las variables que definen las preguntas y sus opciones
    [System.Serializable]
    // el nombre de la variable que almacena cualquier tipo de variable y puede ser llamada desde cualquier otra clase
    public class Question 
    {
        public string question; //alamacena la pregunta
        public string[] answare; // las posibles respuestas
        public int correctAnsware; // el ID de la respuesta correcta
    }
    //aca inicia la Clase QuestionGenerator
    [SerializeField]
    public List<Question> listQuestion; //una lista de variables question generadas en la clase anterior

    public Text label; //acceso publico al texto donde se imprime la pregunta
    public Text labelScore;// acceso publico al texto donde se imprime el score
    public Button answareA; //acceso publico al boton A
    public Button answareB;// acceso publico al boton B
    public UnityEvent endList;

    private int score = 0; //variable entera que almacena el total de los puntos generados por las preguntas correctas 
    
    void Start ()
    {

        foreach (Question var in listQuestion)
        {
            print(var.question);

        }

        RenderQuestion(); //llama al metodo 
    }

    private void ClickAnswer(bool isCorrect) //metodo que devuelve una booleana de la respuesta correcta
    {
        if (isCorrect) //si la respuesta es correcta le suma a la variable score 100 puntos
            score += 100;//valor de cada respuesta correcta 

        labelScore.text = "Score : " + score.ToString(); //imprime el valor de la variable score mas el texto score : ...
        RenderQuestion(); //vuelve a llamar este metodo 
    }

    private void RenderQuestion()
    {
        if (listQuestion.Count>0)
        {
            //variable nueva con el valor del resultado del metodo GetRandomQuestion
            Question currentQuestion = GetRamdomQuestion();
            //la variable donde se imprime la pregunta se llena con el resultado de question.question
            label.text = currentQuestion.question;
            //Busca en el hijo dle boton a y accede a su texto, imprime la respuesta 
            answareA.transform.Find("Text").GetComponent<Text>().text = currentQuestion.answare[0];
            answareB.transform.Find("Text").GetComponent<Text>().text = currentQuestion.answare[1];

            answareA.onClick.RemoveAllListeners();
            answareB.onClick.RemoveAllListeners();
            answareA.onClick.AddListener(() => { ClickAnswer((currentQuestion.correctAnsware == 0) ? true : false); });
            answareB.onClick.AddListener(() => { ClickAnswer((currentQuestion.correctAnsware == 1) ? true : false); });
        }
        else{
            answareA.onClick.RemoveAllListeners();
            answareB.onClick.RemoveAllListeners();
            endList.Invoke();
        }
     
    }

    private Question GetRamdomQuestion()
    {
        Question question;
        int indexRamdom;
        indexRamdom = Random.Range(0, listQuestion.Count);
        question = listQuestion[indexRamdom];
        listQuestion.Remove(question);
        return question;
    }
}
