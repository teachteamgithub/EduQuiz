﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Question {

	public enum QuestionType {MODE2_V = 1, MODE2_H, MODE4};

	private string questionText;
	private QuestionType mode;
	private List<Answer> answerList = new List<Answer>();

	public Question(string questionText, QuestionType mode) {
		this.questionText = questionText;
		this.mode = mode;
	}

	public void addAnswer(string answerText, bool correct) {
		answerList.Add(new Answer(answerText, correct));
	}
	public string getQuestionText() {
		return questionText;
	}
	public QuestionType getQuestionMode() {
		return mode;
	}
	public List<Answer> getAnswers() {
		return answerList;
	}
}
