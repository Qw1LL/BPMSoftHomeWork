namespace BPMSoft.Configuration.FileImport
{
	using System;
	using System.Globalization;
	using System.Text.RegularExpressions;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: FloatColumnProcessor

	/// <inheritdoc cref="NonPersistentColumnProcessor{TResult}"/>
	/// <summary>
	///  An instance of this class is responsible for processing Float column values.
	/// </summary>
	[DefaultBinding(typeof(IColumnProcessor), Name = nameof(FloatColumnProcessor))]
	public class FloatColumnProcessor : NonPersistentColumnProcessor<decimal?>, IColumnProcessor
	{

		#region Constructors: Public

		/// <inheritdoc cref="NonPersistentColumnProcessor{TResult}"/>
		/// <summary>
		///     Creates instance of type <see cref="FloatColumnProcessor"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public FloatColumnProcessor(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Properties: Protected

		/// <inheritdoc cref="NonPersistentColumnProcessor{TResult}"/>
		protected override Guid DataValueTypeUId => DataValueType.FloatDataValueTypeUId;

		#endregion

		#region Methods: Protected

		/// <inheritdoc cref="NonPersistentColumnProcessor{TResult}"/>
		protected override decimal? ConvertValue(ImportColumnValue columnValue) {
			base.ConvertValue(columnValue);
			CultureInfo currentCulture = UserConnection.CurrentUser.Culture;
			string cultureSpecificValue = Regex.Replace(columnValue.Value, "[,.]",
				currentCulture.NumberFormat.NumberDecimalSeparator);
			if (!double.TryParse(cultureSpecificValue, out double valueForSave))
				return null;
			var convertedValue = (decimal)valueForSave;
			return convertedValue;
		}

		#endregion

	}

	#endregion

}

