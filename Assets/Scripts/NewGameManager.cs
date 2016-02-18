﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NewGameManager : MonoBehaviour {

	private Button answ;
	private Button answer1;
	private Button answer2;
	private Button answer3;
	private Button answer4;
	private Text questionText;

	QuestionSetManager questionSetManager;
	// Use this for initialization
	void Start () {
		questionSetManager = new QuestionSetManager ();

		questionText = GameObject.Find ("question_text").GetComponent<Text> ();
		answer1 = GameObject.Find ("answer1_button").GetComponent<Button> ();
		answer2 = GameObject.Find ("answer2_button").GetComponent<Button> ();
		answer3 = GameObject.Find ("answer3_button").GetComponent<Button> ();
		answer4 = GameObject.Find ("answer4_button").GetComponent<Button> ();

		string mode = "";
		string question_text = "";

		List<Question> questionList = questionSetManager.importQuestions ().getQuestionList ();
		Question firstQuestion = questionList [0];
		List<Answer> answerList = firstQuestion.getAnswers ();
		mode = firstQuestion.getQuestionMode ().ToString();
		question_text = firstQuestion.getQuestionText ();

		questionText.text = question_text;

		int i = 1;
		foreach (Answer answer in answerList) {
			if (mode == "MODE2_H") {
				if (i == 1) {
					answer1.GetComponentInChildren<Text> ().text = answer.getText ();

				} else {
					answer3.GetComponentInChildren<Text> ().text = answer.getText ();
				}
			} else {
				string name = "answer" + i.ToString () + "_button"; 
				answ = GameObject.Find (name).GetComponent<Button> ();
				answ.GetComponentInChildren<Text>().text = answer.getText ();
			}
			i++;
		}

		// button resizing and positioning based on the question mode
		if (mode == "MODE2_V") {
			// set size of first button
			answer1.image.rectTransform.sizeDelta = new Vector2 (478, 350);
			//set position of first button
			Vector3 temp = answer1.transform.position;
			temp.x = 250;
			temp.y = 220;
			temp.z = 0;
			answer1.transform.position = temp;

			// set size of second button
			answer2.image.rectTransform.sizeDelta = new Vector2 (478, 350);
			// set position of second button
			temp = answer2.transform.position;
			temp.x = 820;
			temp.y = 220;
			temp.z = 0;
			answer2.transform.position = temp;

			// hide third and fourth button 
			answer3.gameObject.SetActive (false);
			answer4.gameObject.SetActive (false);
		} else if (mode == "MODE2_H") {
			// set size of first button
			answer1.image.rectTransform.sizeDelta = new Vector2 (956, 175);
			//set position of first button
			Vector3 temp = answer1.transform.position;
			temp.x = 500;
			temp.y = 350;
			temp.z = 0;
			answer1.transform.position = temp;

			// set size of third button
			answer3.image.rectTransform.sizeDelta = new Vector2 (956, 175);
			// set position of second button
			temp = answer2.transform.position;
			temp.x = 500;
			temp.y = 100;
			temp.z = 0;
			answer3.transform.position = temp;

			// hide second and fourth button 
			answer2.gameObject.SetActive (false);
			answer4.gameObject.SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}