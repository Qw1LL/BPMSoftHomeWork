namespace BPMSoft.Configuration.Translation
{
	using System;
	using System.Collections.Generic;

	#region Interface: ISysCultureInfoProvider

	public interface ISysCultureInfoProvider
	{

		#region Methods: Public

		/// <summary>
		/// Gets system culture information.
		/// </summary>
		/// <param name="id">System culture identifier.</param>
		ISysCultureInfo Read(Guid id);

		/// <summary>
		/// Gets system culture information.
		/// </summary>
		/// <param name="index">System culture index.</param>
		ISysCultureInfo Read(int index);

		List<ISysCultureInfo> Read();

		int Count();

		#endregion

	}

	#endregion

}

