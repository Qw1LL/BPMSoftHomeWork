namespace BPMSoft.Configuration.Translation
{
	using System.Collections.Generic;

	#region Class: TranslationBatch

	public class TranslationBatch : Dictionary<string, string>, ITranslationBatch
	{

		#region Constructors: Public

		public TranslationBatch(string key) {
			Key = key;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Translation key.
		/// </summary>
		public string Key {
			get;
			private set;
		}

		#endregion

	}

	#endregion

}

