﻿using UnityEngine;
using System.Collections;
using SmoothMoves;

namespace KKR
{
	public class KKRAnimationManager : MonoBehaviour 
	{
		public GameObject swipeAnimation;
		public GameObject clickAnimation;
		public GameObject zoomAnimation;

		void Start () 
		{
			if (EarthScript.guideTrigger) 
			{
				#region Swipe
				Invoke ("Swipe", 1);
				Invoke ("SwipeLeftControl", 2);
				Invoke ("SwipeRightControl", 3);
				Invoke ("SwipeControlReset", 5);
				#endregion

				Invoke ("Click", 6);

                /*
				#region Zoom
				Invoke ("ZoomAnim", 17.5f);
				Invoke ("ZoomFisrt", 19f);
				Invoke ("ZoomSecond", 21f);
				Invoke ("ZoomReset", 23);
                #endregion
                */
                Invoke("AllReset", 9.5f);
			}
		}

		void Update () 
		{

		}

		private void Swipe()
		{
		
			
			swipeAnimation.SetActive (true);
			clickAnimation.SetActive (false);
			zoomAnimation.SetActive (false);
			
		}

		private void SwipeLeftControl()
		{
			EarthScript.leftRotate = false;
			EarthScript.rightRotate = true;
		}

		private void SwipeRightControl()
		{
			EarthScript.leftRotate = true;
			EarthScript.rightRotate = false;
		}

		private void SwipeControlReset()
		{
			EarthScript.leftRotate = false;
			EarthScript.rightRotate = false;
		}

		private void Click()
		{
			swipeAnimation.SetActive (false);
			clickAnimation.SetActive (true);
			zoomAnimation.SetActive (false);
		}

		private void ZoomAnim()
		{
			swipeAnimation.SetActive (false);
			clickAnimation.SetActive (false);
			zoomAnimation.SetActive (true);
			zoomAnimation.GetComponent<BoneAnimation> () ["New Clip"].normalizedTime = 1;
			zoomAnimation.GetComponent<BoneAnimation> () ["New Clip"].speed = -1;
			zoomAnimation.GetComponent<BoneAnimation> ().Play ("New Clip");
		}

		private void ZoomFisrt()
		{
			KKR.ZoomAnim.first = true;	
			KKR.ZoomAnim.second = false;
		}

		private void ZoomSecond()
		{
			KKR.ZoomAnim.first = false;	
			KKR.ZoomAnim.second = true;
		}

		private void ZoomReset()
		{
			KKR.ZoomAnim.first = false;	
			KKR.ZoomAnim.second = false;
		}

		private void AllReset()
		{
			swipeAnimation.SetActive (false);
			clickAnimation.SetActive (false);
			zoomAnimation.SetActive (false);
		}
	}
}
