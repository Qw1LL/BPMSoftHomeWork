namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	/// <summary>
	/// Interface for rules recalculation.
	/// </summary>
	public interface ICaseRuleHandler
	{
		UserConnection UserConnection {
			get;
		}

		/// <summary>
		/// Entry point for rule handling.
		/// </summary>
		/// <param name="entity">Entity</param>
		void Handle (Entity entity);
	}
}

