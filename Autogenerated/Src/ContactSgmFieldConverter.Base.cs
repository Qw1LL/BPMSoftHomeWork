namespace BPMSoft.Configuration {

	using System;
	using System.Linq;
	using System.Text;
	using BPMSoft.Common;

	#region Class: ContactSgmFieldConverter

	/// <summary>
	/// Contact "Full name" field converter class.
	/// Separates "Full name" string using "Surname Given name [Middle name]" rule.
	/// </summary>
	public class ContactSgmFieldConverter : IContactFieldConverter
	{

		#region Properties: Public

		/// <summary>
		/// Contact "Full name" separator characters array.
		/// </summary>
		private char[] _separator = { ' ' };
		public char[] Separator {
			get {
				return _separator;
			}
			set {
				_separator = value;
			}
		}

		#endregion

		#region Methdos: Public

		/// <summary>
		/// <see cref="IContactFieldConverter.GetContactSgm"/>
		/// </summary>
		/// <remarks>
		/// After splitting <paramref name="name"/> first element will be used as <see cref="ContactSgm.Surname"/>,
		/// second element as <see cref="ContactSgm.GivenName"/>, everything else as <see cref="ContactSgm.MiddleName"/>.
		/// </remarks>
		ContactSgm IContactFieldConverter.GetContactSgm(string name) {
			var sgm = new ContactSgm();
			if (string.IsNullOrEmpty(name)) {
				return sgm;
			}
			var array = name.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
			switch (array.Length) {
				case 0:
					return sgm;
				case 1:
					sgm.Surname = array[0];
					break;
				case 2:
					sgm.Surname = array[0];
					sgm.GivenName = array[1];
					break;
				default:
					sgm.Surname = array[0];
					sgm.GivenName = array[1];
					StringBuilder sb = new StringBuilder();
					for (var i = 2; i <= array.Length - 1; i++) {
						sb.AppendFormat("{0} ", array[i]);
					}
					sgm.MiddleName += sb.ToString().Trim();
					break;
			}
			return sgm;
		}

		/// <summary>
		/// <see cref="IContactFieldConverter.GetContactName"/>
		/// </summary>
		/// <remarks>
		/// "Full name" string will be created using "Surname Given name [Middle name]" rule.
		/// </remarks>
		public string GetContactName(ContactSgm sgm) {
			var concatChar = Separator.FirstOrDefault();
			return new[] { sgm.Surname, sgm.GivenName, sgm.MiddleName }.ConcatIfNotEmpty(concatChar.ToString());
		}

		#endregion

	}

	#endregion
	
}
