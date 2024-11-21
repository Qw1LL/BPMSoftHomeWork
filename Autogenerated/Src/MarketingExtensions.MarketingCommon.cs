namespace BPMSoft.Configuration
{
	using System;

	#region Class: Base36Extensions

	/// <summary>
	/// Extensions that helps to shortify the Guid values using the Base36 algorithm.
	/// </summary>
	public static class Base36Extensions
	{

		#region Constants: Private

		private const byte DigitsNumber = 36;
		private const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		#endregion

		#region Methods: Public

		/// <summary>
		/// Calculates a short hash from the bytes array.
		/// </summary>
		/// <param name="data">The array of bytes.</param>
		/// <returns>Approx. 13 symbols [0-9A-Z].</returns>
		private static string ToBase36(this byte[] data) {
			ulong intData = 0;
			for (int i = 0; i < data.Length; i++) {
				intData = intData * 256 + data[i];
			}
			string result = "";
			while (intData > 0) {
				int remainder = (int)(intData % DigitsNumber);
				intData /= DigitsNumber;
				result = Digits[remainder] + result;
			}
			for (int i = 0; i < data.Length && data[i] == 0; i++) {
				result = '1' + result;
			}
			return result;
		}

		/// <summary>
		/// Calculates a short hash from the Guid structure. Uses like Guid shortener. 
		/// </summary>
		/// <param name="guid">Guid instance.</param>
		/// <returns>Approx. 13 symbols [0-9A-Z].</returns>
		public static string ToBase36(this Guid guid) {
			return ToBase36(guid.ToByteArray());
		}

		#endregion

	} 

	#endregion
	
}
