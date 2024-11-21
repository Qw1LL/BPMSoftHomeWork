namespace BPMSoft.Configuration.Translation
{
	using System;

	#region Interface: ISysCultureInfo

	public interface ISysCultureInfo
	{

		#region Properties: Public

		/// <summary>
		/// System culture identifier.
		/// </summary>
		Guid Id {
			get;
		}

		/// <summary>
		/// System culture index.
		/// </summary>
		int Index {
			get;
		}

		/// <summary>
		/// Translation column name.
		/// </summary>
		string TranslationColumnName {
			get;
		}

		/// <summary>
		/// Verification column name.
		/// </summary>
		string VerificationColumnName {
			get;
		}

		string IsChangedColumnName {
			get;
		}

		#endregion

	}

	#endregion

}

