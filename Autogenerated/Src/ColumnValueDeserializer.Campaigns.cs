namespace BPMSoft.Configuration.Campaigns
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;

	#region Class: ColumnValuesDeserializer

	/// <summary>
	/// Element for <see cref="ColumnValuesIterator"/> which deserialized string representation of column value to object.
	/// </summary>
	public class ColumnValuesDeserializer : ColumnValuesIteratorElement
	{

		#region Class: Deserializer

		private abstract class Deserializer
		{

			#region Properties: Public

			public Deserializer Next { get; set; }

			#endregion

			#region Methods: Protected

			protected virtual bool CanProcess(ColumnValue columnValue, ColumnValuesIteratorContext context) => false;

			protected abstract object InternalTryBoxValue(ColumnValue columnValue, ColumnValuesIteratorContext context);

			#endregion

			#region Methods: Public

			public Deserializer LinkNext(Deserializer nextElement) {
				return Next = nextElement;
			}

			public object TryBoxValue(ColumnValue columnValue, ColumnValuesIteratorContext context) {
				if (CanProcess(columnValue, context)) {
					return InternalTryBoxValue(columnValue, context);
				}
				if (Next != null) {
					return Next.TryBoxValue(columnValue, context);
				}
				return null;
			}

			#endregion

		}

		#endregion

		#region Class: DateTimeDeserializer

		private class DateTimeDeserializer : Deserializer
		{
			#region Methods: Private

			private object GetValueForDateTimeDataValueType(DateTime dateTimeValue, DateTimeValueKind kind,
					TimeZoneInfo timeZoneOffset) {
				switch (kind) {
					case DateTimeValueKind.Date:
						return dateTimeValue.Date;
					case DateTimeValueKind.Time:
						return dateTimeValue;
					case DateTimeValueKind.DateTime:
						return TimeZoneInfo.ConvertTimeToUtc(dateTimeValue, timeZoneOffset);
					default:
						return dateTimeValue;
				}
			}

			#endregion

			#region Methods: Protected

			protected override bool CanProcess(ColumnValue columnValue, ColumnValuesIteratorContext context)
				=> columnValue.IsDateTimeColumn;

			protected override object InternalTryBoxValue(ColumnValue columnValue,
					ColumnValuesIteratorContext context) {
				if (!DateTime.TryParse(columnValue.Value?.ToString(), out var dateTimeValue)
						|| dateTimeValue.Equals(DateTime.MinValue)) {
					return null;
				}
				if (columnValue.DataValueType is DateTimeDataValueType dateTimeType) {
					return GetValueForDateTimeDataValueType(dateTimeValue, dateTimeType.Kind, context.TimeZoneOffset);
				}
				return dateTimeValue;
			}

			#endregion

		}

		#endregion

		#region Class: GuidDeserializer

		private class GuidDeserializer : Deserializer
		{

			#region Methods: Protected

			protected override bool CanProcess(ColumnValue columnValue, ColumnValuesIteratorContext context)
				=> columnValue.IsGuidColumn;

			protected override object InternalTryBoxValue(ColumnValue columnValue,
					ColumnValuesIteratorContext context) {
				if (Guid.TryParse(columnValue.Value?.ToString(), out var guidValue) && !Guid.Empty.Equals(guidValue)) {
					return guidValue;
				}
				return null;
			}

			#endregion

		}

		#endregion

		#region Class: BooleanDeserializer

		private class BooleanDeserializer : Deserializer
		{

			#region Methods: Protected

			protected override bool CanProcess(ColumnValue columnValue, ColumnValuesIteratorContext context)
				=> columnValue.IsBooleanColumn;

			protected override object InternalTryBoxValue(ColumnValue columnValue,
					ColumnValuesIteratorContext context) {
				if (bool.TryParse(columnValue.Value?.ToString(), out var boolValue)) {
					return boolValue;
				}
				return null;
			}

			#endregion

		}

		#endregion

		#region Class: StringDeserializer

		private class StringDeserializer : Deserializer
		{

			#region Methods: Protected

			protected override bool CanProcess(ColumnValue columnValue, ColumnValuesIteratorContext context) 
				=> columnValue.IsTextColumn;

			protected override object InternalTryBoxValue(ColumnValue columnValue, ColumnValuesIteratorContext context)
				=> columnValue.Value?.ToString();

			#endregion

		}

		#endregion

		#region Properties: Private

		private Deserializer Deserializers { get; set; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor which defines inner chain of deserializers.
		/// </summary>
		public ColumnValuesDeserializer() {
			InitDeserializers();
		}

		#endregion

		#region Methods: Private

		private void InitDeserializers() {
			Deserializers = new DateTimeDeserializer();
			Deserializers
				.LinkNext(new GuidDeserializer())
				.LinkNext(new BooleanDeserializer())
				.LinkNext(new StringDeserializer());
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Deserializes column values from string to typed value boxing in object.
		/// </summary>
		/// <param name="context">Context for processing elements.</param>
		public override void Process(ColumnValuesIteratorContext context) {
			foreach (var columnValue in context.ColumnValues) {
				if (columnValue.HasMacrosValue) {
					continue;
				}
				var boxedResult = Deserializers.TryBoxValue(columnValue, context);
				var result = new ColumnValueResult(columnValue.ColumnUId) { Value = boxedResult };
				context.Results.Add(columnValue.ColumnUId, result);
			}
		}

		#endregion

	}

	#endregion

}
