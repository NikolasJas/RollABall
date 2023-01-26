using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	public Text countText;
	public Text winText;
	public Text loseText;
	public Text timerText;
	public float speed;
	public int collectablesCount;
	private float totalTime;
	private float timeLeft;
	private bool gameWon;
	public GameObject Next;
	public GameObject Reset;
	public bool isAlive;

	void Start()
	{
		winText.text = "";  //initialize the winText value
		loseText.text = ""; //initialize the loseText value
		Next.gameObject.SetActive(false);
		Reset.gameObject.SetActive(false);
		totalTime = 30;
		timeLeft = totalTime;
		gameWon = false;
		timerText.text = "timer: " + timeLeft.ToString();
		countText.text = "Score: ";
		collectablesCount = 0;
		isAlive = true;

	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");     //Access the right and left arrow keys
		float moveVertical = Input.GetAxis("Vertical");         //Access the up and down arrow keys
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //Vector3s deal with movement in 3D space.  X, Y, and Z aspects.  In this case the Y is zero.  Vector3s take floats.
		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime); //This accesses the rigidbody component and adds force ot get it moving

		timerText.text = "timer: " + timeLeft.ToString("F2");
		if (gameWon == false)
        {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0.00000000001)
            {
				Destroy(gameObject);
				loseText.text = "Time Ran Out!";
				Reset.gameObject.SetActive(true);
			}

        }
		countText.text = "Score: " + collectablesCount + "/3";
		if (collectablesCount >= 3)
        {
			Next.gameObject.SetActive(true);
			winText.text = "Nice job!";
		}
	}
	void OnTriggerEnter(Collider target)
	{
		if (target.tag == "Collect")
		{
			//if a collision with the player occurs, do this.  This can be used to load the next scene.
			Debug.Log("Collected");
			//next.gameObject.SetActive(true);
			collectablesCount++;
		}
		if(target.gameObject.tag == "deadly")

		{
			ImDead();
		}
	}
	public void ImDead()
	{

		isAlive = false;
		//myAnimator.SetBool("Dead", true);
		Reset.SetActive(true);
		//healthbar.value = 0;
	}
}
