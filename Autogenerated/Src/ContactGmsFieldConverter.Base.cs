namespace BPMSoft.Configuration {

	using System;
	using System.Linq;
	using System.Text;
	using BPMSoft.Common;

	#region Class: ContactGmsFieldConverter

	/// <summary>
	/// Contact "Full name" field converter class.
	/// Separates "Full name" string using "Given name [Middle name] Surname" rule.
	/// </summary>
	public class ContactGmsFieldConverter : IContactFieldConverter
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
		/// After splitting <paramref name="name"/> first element will be used as <see cref="ContactSgm.GivenName"/>,
		/// last element as <see cref="ContactSgm.Surname"/>, everything else as <see cref="ContactSgm.MiddleName"/>.
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
					sgm.GivenName = array[0];
					break;
				case 2:
					sgm.GivenName = array[0];
					sgm.Surname = array[1];
					break;
				default:
					sgm.Surname = array[0];
					sgm.MiddleName = array[array.Length - 1];
					StringBuilder sb = new StringBuilder();
					for (var i = 1; i <= array.Length - 2; i++) {
						sb.AppendFormat("{0} ", array[i]);
					}
					sgm.GivenName += sb.ToString().Trim();
					break;
			}
			return sgm;
		}


		/// <summary>
		/// <see cref="IContactFieldConverter.GetContactName"/>
		/// </summary>
		/// <remarks>
		/// "Full name" string will be created using "Given name [Middle name] Surname" rule.
		/// </remarks>
		public string GetContactName(ContactSgm sgm) {
			var concatChar = Separator.FirstOrDefault();
			return new[] { sgm.GivenName, sgm.MiddleName, sgm.Surname }.ConcatIfNotEmpty(concatChar.ToString());
		}

		#endregion

	}

	#endregion
	
}
