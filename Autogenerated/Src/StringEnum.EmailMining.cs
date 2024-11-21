namespace BPMSoft.Configuration.EmailMining
{

	#region Class: StringEnum

	/// <summary>
	/// Base class for string type-safe-enum pattern classes.
	/// </summary>
	public class StringEnum
	{

		#region Fields: Private

		/// <summary>
		/// The value.
		/// </summary>
		private readonly string _value;

		#endregion

		#region Constructors: Protected

		/// <summary>
		/// Initializes a new instance of the <see cref="StringEnum"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
		protected StringEnum(string value) {
			_value = value;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Performs an implicit conversion from <see cref="StringEnum"/> to <see cref="System.String"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static implicit operator string(StringEnum value) {
			return value.ToString();
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString() {
			return _value;
		}

		#endregion

	}

	#endregion

}

