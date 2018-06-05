using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TravelerNavigationManager : MonoBehaviour {

	[SerializeField]
	private PlayerDecisionManager DecisionManager;
	private TravelerGeneratorManager travelerGenerator;
	[SerializeField]
	private GameObject destinationApproval, destinationReject;
	[SerializeField]
	private GameObject TravellerDestination;
	// Use this for initialization
	void Start () {
		if(gameObject.GetComponent<TravelerGeneratorManager>() != null)
		{
			travelerGenerator = gameObject.GetComponent<TravelerGeneratorManager>();
			travelerGenerator.OnTravelerInstantiated += SetTravelerInitialDestination;
		}
		DecisionManager.OnDecisionMade += SetTravelerDestinationForDecision;
	}

	private void SetTravelerInitialDestination(GameObject traveler)
	{
		Debug.Log("set initial destination");
		traveler.GetComponent<NavMeshAgent>().SetDestination(TravellerDestination.transform.position);
	}
	private void SetTravelerDestinationForDecision(bool decision, GameObject traveler)
	{
		NavMeshAgent a = traveler.GetComponent<NavMeshAgent>();
		a.ResetPath();
		if(decision)
		{
			Debug.Log("nav for positive");
			a.SetDestination(destinationApproval.transform.position);
		}else{
			Debug.Log("nav for negative");
			a.SetDestination(destinationReject.transform.position);
		}
		traveler.GetComponent<NavMeshAgent>().isStopped = false;
		traveler.GetComponent<Rigidbody>().freezeRotation = false;
		traveler.GetComponent<Movement>().shouldAnimate = true;
	}

}
