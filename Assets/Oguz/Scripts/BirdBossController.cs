using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBossController : MonoBehaviour
{
	public Transform player;
	public Transform[] movementPoints;
	private Transform travelTargetTransform;
	private Vector2 attackTargetPosition;


	[SerializeField]private Animator birdBossAnimator;



	private int state;
	private int travelCounter;


	private float timer;
	[SerializeField] float beforeAttackWaitingTime;
	[SerializeField] private float movementSpeed;
	[SerializeField] private float attackSpeed;


	void Start()
	{
		travelTargetTransform = GetRandomTargetPosition();
		transform.position = travelTargetTransform.position;
		travelCounter = 0;
		timer = 0;

	}

	// Update is called once per frame
	void Update()
	{

		switch (state)
		{
			case 0: // 0 flying among the all movement points
				transform.position = Vector2.MoveTowards(transform.position, travelTargetTransform.position, movementSpeed * Time.deltaTime);


				if (Vector3.Distance(transform.position, travelTargetTransform.position) < 0.001f)
				{
					travelTargetTransform = GetRandomTargetPosition();
					travelCounter++;
					Debug.Log(travelCounter);
				}

				if (travelCounter >= 5)
				{
					travelCounter = 0;
					state = 1;
				}

				break;
			case 1: // 1 getting ready for attack
				timer += Time.deltaTime;

				if (timer >= beforeAttackWaitingTime)
				{
					attackTargetPosition = player.transform.position;
					timer = 0;
					state = 2;
				}
				break;
			case 2: // 2 while attacking
				birdBossAnimator.SetBool("attack", true);
				transform.position = Vector2.MoveTowards(transform.position, attackTargetPosition, attackSpeed * Time.deltaTime);

				if (Vector3.Distance(transform.position, attackTargetPosition) < 0.001f)
				{
					birdBossAnimator.SetBool("attack", false);
					state = 0;
				}
				break;


			default:
				break;
		}
	}



	private Transform GetRandomTargetPosition()
	{
		int random = Random.Range(0, movementPoints.Length);


		return movementPoints[random];
	}
}

