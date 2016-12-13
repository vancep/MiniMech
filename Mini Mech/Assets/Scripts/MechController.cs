using UnityEngine;
using System.Collections;

enum pivot
{
	rightShoulderPivot, rightUpperArmPivot, rightLowerArmPivot, rightHandPivot, 
	rightUpperLegPivot, rightLowerLegPivot, rightFootPivot, leftShoulderPivot, 
	leftUpperArmPivot, leftLowerArmPivot, leftHandPivot, leftUpperLegPivot, 
	leftLowerLegPivot, leftFootPivot, torsoPivot, headPivot
}

public class MechController : MonoBehaviour 
{
	public GameObject[] pivots = new GameObject[16];
	public float[] rotateSpeed = new float[16];

	private Quaternion[] targetRotation;
	private bool[] rotatePivot;

	/*
	public GameObject rightShoulderPivot;
	public GameObject rightUpperArmPivot;
	public GameObject rightLowerArmPivot;
	public GameObject rightHandPivot;
	public GameObject rightUpperLegPivot;
	public GameObject rightLowerLegPivot;
	public GameObject rightFootPivot;
	public GameObject leftShoulderPivot;
	public GameObject leftUpperArmPivot;
	public GameObject leftLowerArmPivot;
	public GameObject leftHandPivot;
	public GameObject leftUpperLegPivot;
	public GameObject leftLowerLegPivot;
	public GameObject leftFootPivot;
	public GameObject torsoPivot;
	public GameObject headPivot;
	*/

	// Use this for initialization
	void Start () 
	{
		targetRotation = new Quaternion[pivots.Length];
		rotatePivot = new bool[pivots.Length];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.R))
		{
			RandomRotationTest();	
		}

		for(int i = 0; i < pivots.Length; i++)
		{
			if(rotatePivot[i])
			{
				UpdatePivot(i);

				if(pivots[i].transform.rotation == targetRotation[i])
				{
					rotatePivot[i] = false;
				}
			}
		}

	}

	/// <summary>
	/// /*Randomly makes each pivot go to some rotation.
	/// Which makes the mech look REALLY weird.*/
	/// </summary>
	private void RandomRotationTest()
	{
		for(int i = 0; i < 16; i++)
		{
			float x = Random.value * 360.0f;
			float y = Random.value * 360.0f;
			float z = Random.value * 360.0f;

			RotatePivot(i, new Vector3(x, y, z));
		}
	}

	private void RotatePivot(int p, Quaternion direction)
	{
		targetRotation[p] = direction;
		rotatePivot[p] = true;
	}

	private void RotatePivot(int p, Vector3 direction)
	{
		targetRotation[p].eulerAngles = direction;
		rotatePivot[p] = true;
	}

	private void UpdatePivot(int p)
	{
		pivots[p].transform.rotation = Quaternion.RotateTowards(pivots[p].transform.rotation, targetRotation[p], rotateSpeed[p] * Time.deltaTime);
	}
}
