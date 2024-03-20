using Sandbox;

namespace IconKino.Tuts.Respawning;

[Title( "Respawning | Ragdoll" )]
[Category( "📖 IK Tutorials" )]
[Icon( "📖" )]
public sealed class Ragdoll : Component
{
	private CharacterController characterController;
	private PlayerController playerController;
	private ModelPhysics modelPhysics;

	protected override void OnStart()
	{
		base.OnStart();
		characterController = GameObject.Components.Get<CharacterController>( FindMode.EverythingInSelf );
		playerController = GameObject.Components.Get<PlayerController>( FindMode.EverythingInSelf );
		modelPhysics = GameObject.Components.Get<ModelPhysics>( FindMode.EverythingInSelf );
	}

	protected override void OnUpdate()
	{

	}

	public void EnableRagdoll()
	{
		characterController.Enabled = false;		
		playerController.Enabled = false;
		modelPhysics.Enabled = true;
	}

	public void DisabledRagdoll()
	{
		characterController.Enabled = true;		
		playerController.Enabled = true;
		modelPhysics.Enabled = false;
	}
}
