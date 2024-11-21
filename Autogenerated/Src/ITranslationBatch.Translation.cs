namespace BPMSoft.Configuration.Translation
{
	using System.Collections.Generic;

	#region Interface: ITranslationBatch

	public interface ITranslationBatch : IDictionary<string, string>
	{

		#region Properties: Public

		/// <summary>
		/// Translation key.
		/// </summary>
		string Key {
			get;
		}

		#endregion

	}

	#endregion

}

