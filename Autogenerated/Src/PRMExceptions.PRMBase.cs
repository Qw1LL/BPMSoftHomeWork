namespace BPMSoft.Configuration.PRM
{
	using BPMSoft.Common;

	#region Class: FundTypeDuplicateException

	/// <summary>
	/// Occurs when user tries to add fund with type which has already added.
	/// </summary>
	public class FundTypeDuplicateException : NullOrEmptyException
	{

		#region Constructors: Public

		/// <summary>
		/// Creates instance of type <see cref="FundTypeDuplicateException"/>.
		/// </summary>
		/// <param name="storage">Resource storage.</param>
		public FundTypeDuplicateException(IResourceStorage storage) : base(
			new LocalizableString(storage, "PRMExceptions", "LocalizableStrings.FundTypeDuplicateException.Value")) {
		}

		#endregion

	}

	#endregion

}

