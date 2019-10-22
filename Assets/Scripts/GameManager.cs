using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	public Question[] questions;
	private static List<Question> unansweredQuestions;

	private Question currentQuestion;

	[SerializeField]
	private Text factText;

	[SerializeField]
	private static int scorePoints;

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private Text trueAnswerText;

	[SerializeField]
	private Text falseAnswerText;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private float timeBetweenQuestions = 1f;




	void Start()
	{

		if (unansweredQuestions == null || unansweredQuestions.Count == 0) 
		{
			unansweredQuestions = questions.ToList<Question> ();
			
		}

		SetCurrentQuestion ();
		UpdateScore();

	}

	public void AddScore(int newScore){
		scorePoints += newScore;
		UpdateScore();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + scorePoints;
	}



	void SetCurrentQuestion ()
	{
		int randomquestionIndex = Random.Range (0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions [randomquestionIndex];

		factText.text=currentQuestion.fact;

		if (currentQuestion.isTrue) {
			trueAnswerText.text = "CORRECT";
			falseAnswerText.text = "WRONG";
		}
		else
		{
			trueAnswerText.text = "WRONG";
			falseAnswerText.text = "CORRECT";

		}


	}


	IEnumerator TranstionToNextQuestion ()
	{
		unansweredQuestions.Remove (currentQuestion);

		yield return new WaitForSeconds (timeBetweenQuestions);

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}



	public void UserSelectTrue()
	{

		animator.SetTrigger ("True");

		if (currentQuestion.isTrue)
		{
			AddScore(2);
			Debug.Log ("Correct");
		
		}
		else
		{
			AddScore (-2);
			Debug.Log ("Wrong");

		}

		StartCoroutine (TranstionToNextQuestion());


	}
	public void UserSelectFalse()
	{

		animator.SetTrigger ("False");
		if (!currentQuestion.isTrue)
		{
			AddScore(2);
			Debug.Log ("Correct");

		}
		else
		{
			AddScore (-5);
			Debug.Log ("Wrong");

		}

		StartCoroutine (TranstionToNextQuestion());
	}





}
