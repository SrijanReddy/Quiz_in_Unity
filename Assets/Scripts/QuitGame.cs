using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
	void OnMouseDown()
	{
		transform.localScale *= 0.9F;

	}

	void OnMouseUp()
	{
		Application.Quit ();
	}
}