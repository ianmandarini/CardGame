using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
	// The (single) instance
	private static T instance;
	public static Obs afterAwake = new Obs();

	// Gets the instance
	public static T Instance
	{
		get
		{
			if ( instance == null )
			{
				throw new UnityException("Singleton Error - An instance of " + typeof(T) + 
																	" is needed in the scene (some script is trying to use it)," +
																	" but there is none.");
			}
			return instance;
		}
	}

	// Initializes the instance
	protected void Awake ()
	{
		if ( instance == null )
		{
			instance = this as T;
			DontDestroyOnLoad ( gameObject );
			this.onAwake();
			afterAwake.trigger();
		}
		else
		{
			Destroy ( gameObject );
		}
	}

	public virtual void onAwake() {
	}
}
