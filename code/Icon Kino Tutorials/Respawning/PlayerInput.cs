using Sandbox;
using Sandbox.Diagnostics;

namespace IconKino.Tuts.Respawning;

[Title( "Respawning | Player Input" )]
[Category( "📖 IK Tutorials" )]
[Icon( "📖" )]
public sealed class PlayerInput : Component
{
	private Vector3 startingPosition;

	protected override void OnStart()
	{
		base.OnStart();
		Log.Info( "test" );
		startingPosition = Transform.Position;
	}

	protected override void OnUpdate()
	{
		// DROP WEAPON
		if ( Input.Pressed( "Attack1" ) ) Components.Get<DropWeapon>().Drop();
		
		// RESPAWN
		if ( Input.Pressed( "Reload" ) ) Respawn();
	}
	
	/// <summary>
	/// Respawns the player
	/// </summary>
	private void Respawn()
	{
		// Player Health
		Components.Get<Health>().SetToFullHealth();
		// Player Ragdoll
		Components.Get<Ragdoll>().DisabledRagdoll();
		// Knife properties (position, rigidbody, etc)
		Components.Get<DropWeapon>().Reset();
		// Cancel The Velocity
		Components.Get<CharacterController>().Velocity = Vector3.Zero;
		// Player Position
		Transform.Position = startingPosition;
	}
}
