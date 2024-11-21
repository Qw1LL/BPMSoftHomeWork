namespace BPMSoft.Configuration.Translation
{
	using System;
	using BPMSoft.Common;

	#region Class: SysCultureInfo

	public class SysCultureInfo : ISysCultureInfo
	{

		#region Constants: Private

		private const string TranslationColumnPrefix = "Language";
		private const string VerificationColumnPrefix = "IsVerified";
		private const string IsChangedColumnPrefix = "IsChanged";
		private const int MaxCultureIndex = 35;

		#endregion

		#region Constructors: Public

		public SysCultureInfo(Guid id, int index) {
			if (index < 0 || index > MaxCultureIndex) {
				throw new ArgumentOutOfRangeException(
					new LocalizableString("BPMSoft.Common", "Exception.IndexOutOfRangeException"));
			}
			_id = id;
			_index = index;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// System culture identifier.
		/// </summary>
		private Guid _id;
		public Guid Id {
			get {
				return _id;
			}
		}

		/// <summary>
		/// System culture index.
		/// </summary>
		private int _index;
		public int Index {
			get {
				return _index;
			}
		}

		/// <summary>
		/// Translation column name.
		/// </summary>
		private string _translationColumnName;
		public string TranslationColumnName {
			get {
				if (_translationColumnName.IsNullOrEmpty()) {
					_translationColumnName = string.Concat(TranslationColumnPrefix, Index);
				}
				return _translationColumnName;
			}
		}

		/// <summary>
		/// Verification column name.
		/// </summary>
		private string _verificationColumnName;
		public string VerificationColumnName {
			get {
				if (_verificationColumnName.IsNullOrEmpty()) {
					_verificationColumnName = string.Concat(VerificationColumnPrefix, Index);
				}
				return _verificationColumnName;
			}
		}

		private string _isChangedColumnName;
		public string IsChangedColumnName {
			get {
				if (_isChangedColumnName.IsNullOrEmpty()) {
					_isChangedColumnName = string.Concat(IsChangedColumnPrefix, Index);
				}
				return _isChangedColumnName;
			}
		}

		#endregion

	}

	#endregion

}

