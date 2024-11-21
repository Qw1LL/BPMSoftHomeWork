namespace BPMSoft.Configuration.DynamicContent
{
	using System;
	using BPMSoft.Core.DB;

	#region Class: DCSelectBuilderException

	/// <summary>
	/// Exception thrown by <see cref="DCSelectBuilder"/> when <see cref="Select"/> has invalid structure.
	/// </summary>
	public class InvalidQueryStructureException : Exception
	{

		#region Constructors: Public

		/// <summary>
		/// Default constructor.
		/// </summary>
		public InvalidQueryStructureException() {
		}

		/// <summary>
		/// Public constructor for set error message in exception.
		/// </summary>
		/// <param name="message">Exception message.</param>
		public InvalidQueryStructureException(string message)
			: base(message) {
		}

		#endregion

	}

	#endregion

}
