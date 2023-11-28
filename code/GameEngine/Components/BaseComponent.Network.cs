﻿using Sandbox;
using Sandbox.Network;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

public abstract partial class BaseComponent
{
	public GameObject.NetworkAccessor Network => GameObject.Network;

	public bool IsProxy => GameObject.IsProxy;

	protected void __rpc_Broadcast( Action resume, string methodName, params object[] argumentList )
	{
		if ( !Rpc.Calling && Network.Active && SceneNetworkSystem.Instance is not null )
		{
			if ( !Rpc.TryFindMethodIndex( methodName, out var index ) )
			{
				throw new( $"Unindexed RPC method '{methodName}'" );
			}

			var msg = new ObjectMessageMsg();
			msg.Guid = GameObject.Id;
			msg.Component = GetType().Name;
			msg.MethodIndex = index;
			msg.Arguments = argumentList;

			SceneNetworkSystem.Instance.Broadcast( msg );
		}

		Rpc.PreCall();

		// we want to call this
		resume();
	}
	
	protected void __rpc_Authority( Action resume, string methodName, params object[] argumentList )
	{
		if ( !IsProxy || Rpc.Calling )
		{
			Rpc.PreCall();
			
			// If we are already the authority call the original method and return early
			resume();
			return;
		}
		
		if ( Network.Active && SceneNetworkSystem.Instance is not null )
		{
			if ( !Rpc.TryFindMethodIndex( methodName, out var index ) )
			{
				throw new( $"Unindexed RPC method '{methodName}'" );
			}

			var msg = new ObjectMessageMsg();
			msg.Guid = GameObject.Id;
			msg.Component = GetType().Name;
			msg.MethodIndex = index;
			msg.Arguments = argumentList;

			if ( !GameNetworkSystem.IsHost )
				SceneNetworkSystem.Instance.Broadcast( msg );
			else
				SceneNetworkSystem.Instance.Send( Network.OwnerId, msg );
		}
	}
}
