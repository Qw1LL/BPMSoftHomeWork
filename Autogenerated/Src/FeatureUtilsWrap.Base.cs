namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: FeatureUtilsWrap

	[DefaultBinding(typeof(IFeatureUtilities))]
	public class FeatureUtilsWrap : IFeatureUtilities
	{

		#region Methods: Public

		/// <inheritdoc cref="IFeatureUtilities.GetIsFeatureEnabled(UserConnection, string)"/>
		public bool GetIsFeatureEnabled(UserConnection uc, string code) {
			return uc.GetIsFeatureEnabled(code);
		}

		/// <inheritdoc cref="IFeatureUtilities.GetIsFeatureEnabledForAnyUser(UserConnection, string)"/>
		public bool GetIsFeatureEnabledForAnyUser(UserConnection uc, string code) {
			return uc.GetIsFeatureEnabledForAnyUser(code);
		}

		#endregion

	}

	#endregion

}
