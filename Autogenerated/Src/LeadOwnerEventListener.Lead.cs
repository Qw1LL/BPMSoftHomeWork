namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: LeadOwnerEventListener

	/// <summary>
	/// Listener of owner on Lead entity.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Lead")]
	public class LeadOwnerEventListener : BaseEntityOwnerEventListener
	{

	}

	#endregion

}

