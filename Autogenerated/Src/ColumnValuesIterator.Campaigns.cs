namespace BPMSoft.Configuration.Campaigns
{
	using System.Collections.Generic;

	#region Class: ColumnValuesIterator

	/// <summary>
	/// Iterates by <see cref="ColumnValuesIteratorElement"/>.
	/// </summary>
	public class ColumnValuesIterator
	{

		#region Properties: Protected

		/// <summary>
		/// Elements collection for iterate.
		/// </summary>
		protected List<ColumnValuesIteratorElement> Elements { get; set; } = new List<ColumnValuesIteratorElement>();

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor which initialize iterator collection.
		/// </summary>
		public ColumnValuesIterator() {
			Init();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Initialized collection of elements <see cref="Elements"/>.
		/// </summary>
		protected virtual void Init() {
			Elements.Add(new ColumnValuesDeserializer());
			Elements.Add(new MacroValueReplacer());
			Elements.Add(new MultiMacrosValueReplacer());
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Process each element from <see cref="Elements"/>.
		/// </summary>
		/// <param name="context">Context for processing elements.</param>
		public void Process(ColumnValuesIteratorContext context) {
			foreach (var element in Elements) {
				element.Process(context);
			}
		}

		#endregion

	}

	#endregion

}
