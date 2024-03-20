using Sandbox;

namespace IconKino.Tuts.Respawning;

[Title( "Respawning | Fire" )]
[Category( "📖 IK Tutorials" )]
[Icon( "📖" )]
public sealed class Fire : Component, Component.ITriggerListener
{
	[Property] public int fireDamage;
	
	public void OnTriggerEnter( Collider other )
	{
		if ( other.GameObject.Components.TryGet<Health>( out Health health ) )
		{
			health.TakeDamage( fireDamage );
		}
	}
}
