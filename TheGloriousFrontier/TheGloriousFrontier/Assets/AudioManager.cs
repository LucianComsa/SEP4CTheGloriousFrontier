 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	[SerializeField]
	GameObject TravelerArrival; 
	
	[SerializeField]	
	GameObject DocsPanel;

	[SerializeField]
	GameObject Canvas;

	[SerializeField]
	GameObject PlayerDecisionManagerObject;

	AudioSource AudioSource;

	[SerializeField]
	List<AudioClip> Audioclips;

	void Start () {
		AudioSource = transform.GetComponent<AudioSource>();
		
		if (TravelerArrival != null) {
			TravelerArrivalInterraction travelerArrivalInterraction = TravelerArrival.GetComponent<TravelerArrivalInterraction>();
			if (travelerArrivalInterraction != null) {
				travelerArrivalInterraction.OnTravelerArrival += PlayGreetingsClip;
				//travelerArrivalInterraction.OnTravelerLeft += PlayGoodbyeClip;
			}
		}

		if (DocsPanel != null) {
			DocsPanelFiller DocsPanelFiller = DocsPanel.GetComponent<DocsPanelFiller>();
			if (DocsPanelFiller != null) {
				DocsPanelFiller.OnDocsOpened += PlayDocsOpenedClip;
			}
		}
		if (Canvas != null) {
			Timer timer = Canvas.GetComponent<Timer> ();
			if (timer != null) {
				timer.OnLevelFinishedSetupDone += PlaySoundForLevelFinished;
			}
		}
		if (PlayerDecisionManagerObject != null) {
			PlayerDecisionManager decisionManager = PlayerDecisionManagerObject.GetComponent<PlayerDecisionManager> ();
			if (decisionManager != null) {
				decisionManager.DecisionSoundEvent += PlaySoundForDecision;
			}
		}

		GameObject radioGO = transform.Find("radio").gameObject;
		if (radioGO != null) {
			AudioSource radioAudioSource = radioGO.GetComponent<AudioSource>();
			if(radioAudioSource != null) radioAudioSource.clip = Audioclips[2];
		}
	}

	void PlayGreetingsClip() {
		AudioSource.clip = Audioclips[0];
		AudioSource.Play();
	}

	void PlayGoodbyeClip() {
		AudioSource.clip = Audioclips[1];
		AudioSource.Play();
	}

	void PlayDocsOpenedClip() {
		AudioSource.clip = Audioclips[3];
		AudioSource.Play();
	}
	void PlaySoundForDecision(bool decision)
	{
		if (decision)
			StartCoroutine(PlayAcceptTravelerClip ());
		else
			StartCoroutine (PlayRejectTravelerClip ());
	}
	IEnumerator PlayAcceptTravelerClip()
	{
		AudioSource.clip = Audioclips[4];
		AudioSource.Play();
		yield return new WaitForSeconds (AudioSource.clip.length);
		PlayGoodbyeClip ();
	}
	IEnumerator PlayRejectTravelerClip()
	{
		AudioSource.clip = Audioclips[5];
		AudioSource.Play();
		yield return new WaitForSeconds (AudioSource.clip.length);
		PlayGoodbyeClip ();

	}
	void PlaySoundForLevelFinished()
	{
		AudioSource.clip = Audioclips[6];
		AudioSource.Play();
	}
}
