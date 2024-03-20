using Sandbox;

namespace IconKino.Tuts.Respawning;

[Title( "Respawning | Health" )]
[Category( "📖 IK Tutorials" )]
[Icon( "📖" )]
public sealed class Health : Component, Component.ITriggerListener
{
	[Category("References")] [Property] public TextRenderer HealthText { get; set; }
	[Category("Health")] [Property] public int CurrentHealth { get; set; } = 100;

	protected override void OnStart()
	{
		base.OnStart();
		UpdateHealthText();
	}

	protected override void OnUpdate()
	{
		if ( CurrentHealth <= 0 )
		{
			Die();
		}
	}

	/// <summary>
	/// Make this object take damage.
	/// </summary>
	/// <returns>How much damage the object took</returns>
	public int TakeDamage(int damage)
	{
		CurrentHealth -= damage;
		UpdateHealthText();
		return damage;
	}

	private void UpdateHealthText()
	{
		HealthText.Text = $"Current HP: {CurrentHealth}";
	}

	private void Die()
	{
		Components.Get<Ragdoll>(FindMode.EverythingInSelf).EnableRagdoll();
		Components.Get<DropWeapon>(FindMode.EverythingInSelf).Drop();
	}

	private void Respawn()
	{
		
	}
}
