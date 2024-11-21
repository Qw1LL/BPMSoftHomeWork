namespace BPMSoft.Configuration.ESN
{
	using Core;

	#region  Interface: IEsnCenterFactory

	/// <summary>
	/// Provides methods for creating instance of implement <see cref="IEsnCenter" />.
	/// </summary>
	public interface IEsnCenterFactory
	{
		/// <summary>
		/// Create instance of implement <see cref="IEsnCenter" />.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection" />.</param>
		/// <returns>Return instance of implement <see cref="IEsnCenter" />.</returns>
		IEsnCenter CreateEsnCenter(UserConnection userConnection);
	}

	#endregion
}

