using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class takeData : MonoBehaviour
{

    GameObject answerbuttons;
    private dataController controller;
    public Text Questiontext;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    public Text timeRemainText;
    public Text Scoretext;
    int Score = 0;
    private float timeRemain;
    bool questionAvaible = true;
    int questioncounter = 0;
    int truecounter = 0;
    int howmanyquestioncounter;
    public GameObject endgamePanel;
    public GameObject gameoverPanel;

    void Start()
    {
        answerbuttons = GameObject.Find("Canvas");
        controller = FindObjectOfType<dataController>(); // take input from first scene
        timeRemain = controller.allRoundData[0].timeLimitInSeconds; // taking questions's given time
        howmanyquestioncounter = controller.allRoundData.Length; // check how many question
        Debug.Log("Question counter"+howmanyquestioncounter);


    }

    
    void Update()
    {
        Questiontext.text = controller.allRoundData[questioncounter].questions[0].questionText; // writing question
        timeRemain -= Time.deltaTime; // decreasing time
        UpdateTimeDisplay();
        Debug.Log(timeRemain);
        //Debug.Log(truecounter+"true answers left"); //for testing how many true answer in my all answers
        if (Mathf.Round(timeRemain) == 0) // if timeRemain = 0 then gameover!!
        {
            gameoverPanel.SetActive(true);

        }
        if (questionAvaible==true)
        {
            AnswersControl();
            questionAvaible=false;
        }
        if (truecounter == 0) // there is no true answers and we have to move on the next question
        {
            if (questioncounter < howmanyquestioncounter-1) //still question left
            {
                questioncounter++;
                questionAvaible = true;
                answerbuttons.transform.GetChild(2).GetComponent<UnityEngine.UI.Button>().interactable = true;
                answerbuttons.transform.GetChild(3).GetComponent<UnityEngine.UI.Button>().interactable = true;
                answerbuttons.transform.GetChild(4).GetComponent<UnityEngine.UI.Button>().interactable = true;
                answerbuttons.transform.GetChild(5).GetComponent<UnityEngine.UI.Button>().interactable = true;
                timeRemain = controller.allRoundData[questioncounter].timeLimitInSeconds;
            }
            else //Game finished there is no another question
            {
                questionAvaible = false;
                endgamePanel.SetActive(true);
            }
            
            
        }
        
    }
    private void UpdateTimeDisplay()
    {
        timeRemainText.text = "Time:  "+ Mathf.Round(timeRemain).ToString();
    } //displaying time to the screen
    void AnswersControl()
    {
        if (controller.allRoundData[questioncounter].questions[0].answers[0].falseAnswerText == "")
        {
            answer1.text = controller.allRoundData[questioncounter].questions[0].answers[0].trueAnswerText;
            truecounter++;

        }
        else
        {
            answer1.text = controller.allRoundData[questioncounter].questions[0].answers[0].falseAnswerText;
            
        }
        if (controller.allRoundData[questioncounter].questions[0].answers[1].falseAnswerText == "")
        {
            answer2.text = controller.allRoundData[questioncounter].questions[0].answers[1].trueAnswerText;
            truecounter++;
        }
        else
        {
            answer2.text = controller.allRoundData[questioncounter].questions[0].answers[1].falseAnswerText;
            
        }
        if (controller.allRoundData[questioncounter].questions[0].answers[2].falseAnswerText == "")
        {
            answer3.text = controller.allRoundData[questioncounter].questions[0].answers[2].trueAnswerText;
            truecounter++;
        }
        else
        {
            answer3.text = controller.allRoundData[questioncounter].questions[0].answers[2].falseAnswerText;
            
        }
        if (controller.allRoundData[questioncounter].questions[0].answers[3].falseAnswerText == "")
        {
            answer4.text = controller.allRoundData[questioncounter].questions[0].answers[3].trueAnswerText;
            truecounter++;
        }
        else
        {
            answer4.text = controller.allRoundData[questioncounter].questions[0].answers[3].falseAnswerText;
            
        }
        
    }  // checking the answers true or not
    public void AnswerButton1()
    {
       if(controller.allRoundData[questioncounter].questions[0].answers[0].iscorrect == true)
        {
            Score = Score + controller.allRoundData[questioncounter].pointAddedCorrectAnswers;
            Scoretext.text = "Score=  " + Score.ToString();
            truecounter--;
        }
        else
        {
            timeRemain -= 10;
        }
        answerbuttons.transform.GetChild(2).GetComponent<UnityEngine.UI.Button>().interactable = false; //sorulacak var UI.Button yazmadanda görmesi lazým
    } // control the button 1 starting from right to ledt in game scene
    public void AnswerButton2()
    {
        if (controller.allRoundData[questioncounter].questions[0].answers[1].iscorrect == true)
        {
            Score = Score + controller.allRoundData[questioncounter].pointAddedCorrectAnswers;
            Scoretext.text = "Score=  " + Score.ToString();
            truecounter--;
        }
        else
        {
            timeRemain -= 10;
        }
        answerbuttons.transform.GetChild(3).GetComponent<UnityEngine.UI.Button>().interactable = false;
    } // control the button 2
    public void AnswerButton3()
    {
        if (controller.allRoundData[questioncounter].questions[0].answers[2].iscorrect == true)
        {
            Score = Score + controller.allRoundData[questioncounter].pointAddedCorrectAnswers;
            Scoretext.text = "Score=  " + Score.ToString();
            truecounter--;
        }
        else
        {
            timeRemain -= 10;
        }
        answerbuttons.transform.GetChild(4).GetComponent<UnityEngine.UI.Button>().interactable = false;
    } // control the button 3
    public void AnswerButton4()
    {
        if (controller.allRoundData[questioncounter].questions[0].answers[3].iscorrect == true)
        {
            Score = Score + controller.allRoundData[questioncounter].pointAddedCorrectAnswers;
            Scoretext.text = "Score=  " + Score.ToString();
            truecounter--;
        }
        else
        {
            timeRemain -= 10;
        }
        answerbuttons.transform.GetChild(5).GetComponent<UnityEngine.UI.Button>().interactable = false;
    } // control the button 4
    public void RestartgameButton()
    {
        Destroy(controller);
        SceneManager.LoadScene(0);
    } //restart game button
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!!!!!");
    } // quit game button
}
