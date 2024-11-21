namespace BPMSoft.Configuration {
	using System;
	using BPMSoft.Core;

	#region Interface: ILeadQualificationHelper

	/// <summary>
	/// ######### helper-# ### ######## ############ #####.
	/// </summary>
	public interface ILeadQualificationHelper {

		/// <summary>
		/// ######## ########### ##### ############# ####.
		/// </summary>
		/// <param name="leadId">########## ############# ####.</param>
		void ActionAfterIdentification(Guid leadId);
	}

	#endregion

	#region class: LeadQualificationHelper

	/// <summary>
	/// ##### helper ### ######## ############ #####.
	/// </summary>
	public class LeadQualificationHelper: ILeadQualificationHelper {

		#region Fileds: Protected

		/// <summary>
		/// ######### ################# ###########.
		/// </summary>
		protected readonly UserConnection UserConnection;

		/// <summary>
		/// URL ##########.
		/// </summary>
		protected readonly string ApplicationUrl;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// ############## ##### ######### ###### <see cref="LeadQualificationHelper"/>.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		/// <param name="applicationUrl">URL ##########.</param>
		public LeadQualificationHelper(UserConnection userConnection, string applicationUrl) {
			UserConnection = userConnection;
			ApplicationUrl = applicationUrl;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ######## ########### ##### ############# ####.
		/// </summary>
		/// <param name="leadId">########## ############# ####.</param>
		public virtual void ActionAfterIdentification(Guid leadId) {
		}

		#endregion

	}

	#endregion

}

