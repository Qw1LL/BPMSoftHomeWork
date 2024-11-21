namespace BPMSoft.Configuration.Campaigns
{

	#region Class: ColumnValuesIteratorElement

	/// <summary>
	/// Abstract element for <see cref="ColumnValuesIterator"/>.
	/// </summary>
	public abstract class ColumnValuesIteratorElement
	{

		#region Methods: Public

		/// <summary>
		/// Makes action with macros values and column values.
		/// </summary>
		/// <param name="context">Context for processing elements.</param>
		public abstract void Process(ColumnValuesIteratorContext context);

		#endregion

	}

	#endregion

}
