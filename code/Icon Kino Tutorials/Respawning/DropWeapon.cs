using Sandbox;
using Sandbox.Diagnostics;

namespace IconKino.Tuts.Respawning;

[Title( "Respawning | Drop Weapon" )]
[Category( "📖 IK Tutorials" )]
[Icon( "📖" )]
public sealed class DropWeapon : Component
{
	[Property] public GameObject WeaponToDrop { get; set; }
	
	private GameObject startingParent;
	private Vector3 startingLocalPosition;
	private Rotation startingLocalRotation;
	private Rigidbody rb;
	
	protected override void OnStart()
	{
		base.OnStart();
		rb = WeaponToDrop.Components.Get<Rigidbody>(FindMode.EverythingInSelf);
		startingParent = WeaponToDrop.Parent;
		startingLocalPosition = WeaponToDrop.Transform.LocalPosition;
		startingLocalRotation = WeaponToDrop.Transform.LocalRotation;
	}

	public void Drop()
	{
		WeaponToDrop.SetParent(Scene.Root);
		rb.Enabled = true;
	}

	public void Reset()
	{
		WeaponToDrop.SetParent(startingParent);
		rb.Enabled = false;
		WeaponToDrop.Transform.LocalPosition = startingLocalPosition;
		WeaponToDrop.Transform.LocalRotation = startingLocalRotation;
	}
	
}
