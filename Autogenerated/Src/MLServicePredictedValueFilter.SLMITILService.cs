namespace BPMSoft.Configuration.ML
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.ML.Interfaces;

	#region Class: MLServicePredictedValueFilter

	/// <summary>
	/// Handler for Service field prediction and filtering.
	/// </summary>
	[Override]
	public class MLServicePredictedValueFilter: MLBasePredictedValueFilter
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="MLServicePredictedValueFilter"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public MLServicePredictedValueFilter(UserConnection userConnection): base(userConnection) {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Called when entity field needs to be set by predicted value.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="columnValueName">Name of the column value.</param>
		/// <param name="result">The predicted value.</param>
		/// <returns><c>true</c> - if value is allowed to be set, else - <c>false</c>.</returns>
		public override bool OnSetupPredictedValue(Entity entity, string columnValueName,
				ClassificationResult result) {
			if (!base.OnSetupPredictedValue(entity, columnValueName, result)) {
				return false;
			}
			if (columnValueName != "ServiceItemId") {
				return true;
			}
			if (!Guid.TryParse(result.Value, out var serviceItemId)) {
				Log.Warn($"Service item value {result.Value} was not set as it's not a valid GUID");
				return false;
			}
			Guid servicePactId = entity.GetTypedColumnValue<Guid>("ServicePactId");
			var select = (Select)new Select(UserConnection)
					.Column(Column.Const(1))
				.From("ServiceInServicePact").As("sp")
				.InnerJoin("ServiceStatus").As("ss").On("sp", "StatusId").IsEqual("ss", "Id")
				.Where("sp", "ServiceItemId").IsEqual(Column.Parameter(serviceItemId, "Guid"))
					.And("sp", "ServicePactId").IsEqual(Column.Parameter(servicePactId, "Guid"))
					.And("ss", "Active").IsEqual(Column.Parameter(true, "Boolean"));
			try {
				bool isValidValue = select.ExecuteScalar<int>() > 0;
				if (!isValidValue) {
					Log.Warn($"Service item value {serviceItemId} was not set as it doesn't suit {servicePactId} " +
						$"Service agreement or is not active");
				}
				return isValidValue;
			} catch (Exception e) {
				Log.Error($"MLServicePredictedValueFilter.OnSetupPredictedValue throws exception {e}");
				return false;
			}
		}

		#endregion

	}

	#endregion

}

