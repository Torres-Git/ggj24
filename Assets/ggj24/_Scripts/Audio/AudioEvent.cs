using UnityEngine;

namespace Serrot.Audio
{
public abstract class AudioEvent : ScriptableObject
{
	public abstract void Play(AudioSource source);
}
}