using System;

namespace BPMSoft.Configuration
{
	public static class OpportunityConstants
	{
		/// <summary>
		// Closed rejected stage.
		/// </summary>
		public static readonly Guid OpportunityClosedRejectedId = new Guid("736F54FD-E240-46F8-8C7C-9066C30AFF59");

		/// <summary>
		// Closed rerouted stage.
		/// </summary>
		public static readonly Guid OpportunityClosedReroutedId = new Guid("9abf243c-fc00-45cf-8e28-cdb66c9208b0");

		/// <summary>
		// Closed won stage.
		/// </summary>
		public static readonly Guid OpportunityClosedWonId = new Guid("60d5310c-5be6-df11-971b-001d60e938c6");

		/// <summary>
		// Closed lost stage.
		/// </summary>
		public static readonly Guid OpportunityClosedLostId = new Guid("a9aafdfe-2242-4f42-8cd5-2ae3b9556d79");
	}
}

