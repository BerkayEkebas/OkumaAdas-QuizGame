using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dataController : MonoBehaviour
{
    public roundData[] allRoundData;
    public InputField questionInputField;
    public InputField answersInputField;
    int howManyQuestion;
    int howManyAnswers;
    GameObject buttons;
    bool answerIstrue = true;
    bool trueorfalseSelected = false;
    int questioncounter;
    int answerscounter;
    int otherscene = 0;

    void Start()
    {
        buttons = GameObject.Find("Canvas");
        questioncounter = 0;
        answerscounter = 0;
        buttons.transform.GetChild(1).GetComponent<Button>().interactable = false; // SaveQuestion inactive
        buttons.transform.GetChild(5).GetComponent<Button>().interactable = false; //Add answers inactive
        buttons.transform.GetChild(6).GetComponent<Button>().interactable = false; //Start Game inactive
        howManyQuestion = allRoundData.Length; // you can use the find how many question you can enter in the game 
        howManyAnswers = allRoundData[0].questions[0].answers.Length;
        //Debug.Log(howManyQuestion); decide how many question will be in the game you can manage that in Unity -Dontdeletedata -Inspector

    }
    void LateUpdate()
    {
        if (otherscene == 0)
        {
            if (answerscounter == 4)
            {
                buttons.transform.GetChild(1).GetComponent<Button>().interactable = true;   // Save Question Active
                buttons.transform.GetChild(3).GetComponent<Button>().interactable = false;  // falseanswers inactive
                buttons.transform.GetChild(2).GetComponent<Button>().interactable = false;  // trueanswers inactive
                buttons.transform.GetChild(5).GetComponent<Button>().interactable = false; // Add answers inactive
            }
            if (howManyQuestion == questioncounter)
            {
                buttons.transform.GetChild(6).GetComponent<Button>().interactable = true; //Start Game active
                buttons.transform.GetChild(3).GetComponent<Button>().interactable = false; //falsebutton inactive
                buttons.transform.GetChild(5).GetComponent<Button>().interactable = false; //Add answers inactive
                buttons.transform.GetChild(2).GetComponent<Button>().interactable = false; // truebutton inactive
            }
            if (trueorfalseSelected == true)
            {
                buttons.transform.GetChild(5).GetComponent<Button>().interactable = true;

            }
            else
            {
                buttons.transform.GetChild(5).GetComponent<Button>().interactable = false;
            }
            buttons.transform.GetChild(7).GetComponent<Text>().text = (howManyQuestion - questioncounter) + "     Question Left";
            buttons.transform.GetChild(8).GetComponent<Text>().text = (howManyAnswers - answerscounter) + "     Answers Left";
        }
     
    }
    public roundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }
    
    public void TrueAnswerButton()
    {
        buttons.transform.GetChild(3).GetComponent<Button>().interactable = false; // making Falseanswer inactive
        answerIstrue=true;  //setting answer true
        trueorfalseSelected = true; //checking false button or true button selected
    }
    public void FalseAnswerButton()
    {
        buttons.transform.GetChild(2).GetComponent<Button>().interactable = false; // making trueanswer inactive
        answerIstrue =false;
        trueorfalseSelected = true;
    }
    public void SaveAnswers()
    {
       
        if (answerIstrue == true)
        {
            allRoundData[questioncounter].questions[0].answers[answerscounter].trueAnswerText = answersInputField.text; //saving true answer
            buttons.transform.GetChild(3).GetComponent<Button>().interactable = true; // active false button
            allRoundData[questioncounter].questions[0].answers[answerscounter].iscorrect = true;
            answerscounter++;
            answersInputField.text = "";
            trueorfalseSelected = false;
        }
        else
        {
            allRoundData[questioncounter].questions[0].answers[answerscounter].falseAnswerText = answersInputField.text; //saving false answer
            buttons.transform.GetChild(2).GetComponent<Button>().interactable = true; //active true button
            allRoundData[questioncounter].questions[0].answers[answerscounter].iscorrect = false;
            answerscounter++;
            answersInputField.text = "";
            trueorfalseSelected = false;
        }


    }
    public void SaveQuestion()
    {
        if (questioncounter < howManyQuestion)
        {


            allRoundData[questioncounter].questions[0].questionText = questionInputField.text;
            questioncounter++;
            buttons.transform.GetChild(1).GetComponent<Button>().interactable = false;   // Save Question Active
            buttons.transform.GetChild(3).GetComponent<Button>().interactable = true;  // falseanswers inactive
            buttons.transform.GetChild(2).GetComponent<Button>().interactable = true;  // trueanswers inactive
            buttons.transform.GetChild(5).GetComponent<Button>().interactable = true; // Add answers inactive
            answerscounter = 0;
            questionInputField.text = "";
            Debug.Log(questioncounter);
        }
        else
        {
            buttons.transform.GetChild(1).GetComponent<Button>().interactable = true; //Save Question inactive
        }
    }
    public void StartGame()
    {
        otherscene = 1;
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(gameObject);
    }



}
