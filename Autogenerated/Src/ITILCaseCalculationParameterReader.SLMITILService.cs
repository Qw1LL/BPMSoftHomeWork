namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;


	/// <summary>
	/// Forms parameters for CaseEntryPoint
	/// </summary>
	[Override]
	public class ITILCaseCalculationParameterReader: CaseCalculationParameterReader
	{
		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="ITILCaseCalculationParameterReader"/> class.
		/// </summary>
		public ITILCaseCalculationParameterReader() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ITILCaseCalculationParameterReader"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public ITILCaseCalculationParameterReader(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Get list of params for calculation.
		/// </summary>
		/// <returns>List of params for calculation.</returns>
		protected override Dictionary<string, string> GetParamsDictionary() {
			Dictionary<string, string> result = base.GetParamsDictionary();
			result.Add("ServicePact.Id", "ServicePactId");
			result.Add("SupportLevel.Id", "SupportLevelId");
			return result;
		}

		#endregion
	}
}
