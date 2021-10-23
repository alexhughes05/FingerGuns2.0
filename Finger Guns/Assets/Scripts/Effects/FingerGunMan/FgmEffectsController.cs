using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FgmEffectsController : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem _walkingParticles;
	[SerializeField]
	private ParticleSystem _landingParticles;

	public void EnableWalkParticles()
	{
		_walkingParticles.Play();
	}
	public void DisableWalkParticles()
	{
		_walkingParticles.Stop();
	}
	public void EnableLandingParticles()
    {
		_landingParticles.Play();
    }
	public void DisableLandingParticles()
	{
		_landingParticles.Stop();
	}
}
