namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using System.Linq;


	/// <summary>
	/// Forms parameters for CaseEntryPoint
	/// </summary>
	public class CaseCalculationParameterReader
	{
		#region Properties : Protected

		/// <summary>
		/// Gets the user connection.
		/// </summary>
		/// <value>
		/// The user connection.
		/// </value>
		protected UserConnection UserConnection {
			get;
			private set;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="CaseCalculationParameterReader"/> class.
		/// </summary>
		public CaseCalculationParameterReader() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CaseCalculationParameterReader"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public CaseCalculationParameterReader(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Get list of params for calculation.
		/// </summary>
		/// <returns>List of params for calculation.</returns>
		protected virtual Dictionary<string, string> GetParamsDictionary() {
			return new Dictionary<string, string>() {
				{"Id", "CaseId"},
				{"Status.Id", "StatusId"},
				{"Priority.Id", "PriorityId"},
				{"ServiceItem.Id", "ServiceItemId"},
				{"SolutionOverdue", "SolutionOverdue"}
			};
		}

		/// <summary>
		/// Get dictionary of params and values for calculation.
		/// </summary>
		/// <param name="paramsDictionary">List of params.</param>
		/// <param name="caseId">Id of current case.</param>
		/// <returns>Dictionary of params and values for calculation.</returns>
		protected virtual Dictionary<string, object> GetParamsDictionary(Dictionary<string, string> paramsDictionary, Guid caseId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Case");
			Dictionary<string, string> paramNames = new Dictionary<string, string>();
			foreach (var name in paramsDictionary.Keys) {
				paramNames.Add(esq.AddColumn(name).Name, paramsDictionary[name]);
			}
			Entity entity = esq.GetEntity(UserConnection, caseId);
			Dictionary<string, object> resultDictionary = new Dictionary<string, object>();
			foreach (var name in paramNames.Keys) {
				resultDictionary.Add(paramNames[name], entity.GetColumnValue(name));
			}
			return resultDictionary;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get dictionary of params and values for calculation.
		/// </summary>
		/// <param name="caseId">Id of current case.</param>
		/// <returns>Dictionary of params and values for calculation.</returns>
		public virtual Dictionary<string, object> GetParams(Guid caseId) {
			Dictionary<string, string> paramsDictionary = GetParamsDictionary();
			Dictionary<string, object> resultDictionary = GetParamsDictionary(paramsDictionary, caseId);
			return resultDictionary;
		}

		#endregion
	}
}

