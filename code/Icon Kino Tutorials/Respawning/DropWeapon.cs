using Sandbox;
using Sandbox.Diagnostics;

namespace IconKino.Tuts.Respawning;

[Title( "Respawning | Drop Weapon" )]
[Category( "📖 IK Tutorials" )]
[Icon( "📖" )]
public sealed class DropWeapon : Component
{
	[Property] public GameObject WeaponToDrop { get; set; }
	protected override void OnUpdate()
	{
		if ( Input.Pressed( "Attack1" ) )
		{
			Drop();
		}		
	}

	public void Drop()
	{
		WeaponToDrop.SetParent(Scene.Root);
		WeaponToDrop.Components.TryGet<Rigidbody>( out Rigidbody rb, FindMode.EverythingInSelf );
		rb.Enabled = true;
	}
}
