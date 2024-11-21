namespace BPMSoft.Configuration
{

	using System;
	using System.Text;
	using System.Security.Cryptography;

	#region Interface: IStringCrypto

	/// <summary>
	/// The interface describes the encryption and decryption.
	/// </summary>
	public interface IStringCrypto
	{
		string EncryptString(string message, string passphrase);
		string DecryptString(string message, string passphrase);
	}

	#endregion

	#region Class: SimpleCrypto

	/// <summary>
	/// Implementation of the 3DES algorithm.
	/// </summary>
	public class SimpleCrypto : IStringCrypto
	{

		#region Methods: Public

		/// <summary>
		/// Encrypts string.
		/// </summary>
		/// <param name="message">Source string.</param>
		/// <param name="passphrase">Encryption key.</param>
		/// <returns>Encrypted string.</returns>
		public string EncryptString(string message, string passphrase) {
			byte[] results;
			UTF8Encoding utf8 = new UTF8Encoding();
			MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
			byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(passphrase));
			using (var tdesAlgorithm = new TripleDESCryptoServiceProvider()) {
				tdesAlgorithm.Key = tdesKey;
				tdesAlgorithm.Mode = CipherMode.ECB;
				tdesAlgorithm.Padding = PaddingMode.PKCS7;
				byte[] dataToEncrypt = utf8.GetBytes(message);
				using (ICryptoTransform encryptor = tdesAlgorithm.CreateEncryptor()) {
					results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
				}
			}
			return Convert.ToBase64String(results);
		}

		/// <summary>
		/// Decrypts string.
		/// </summary>
		/// <param name="message">Encrypted string.</param>
		/// <param name="passphrase">Decryption key.</param>
		/// <returns>Decrypted string.</returns>
		public string DecryptString(string message, string passphrase) {
			byte[] results;
			UTF8Encoding utf8 = new UTF8Encoding();
			MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
			byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(passphrase));
			using (var tdesAlgorithm = new TripleDESCryptoServiceProvider()) {
				tdesAlgorithm.Key = tdesKey;
				tdesAlgorithm.Mode = CipherMode.ECB;
				tdesAlgorithm.Padding = PaddingMode.PKCS7;
				byte[] dataToDecrypt = Convert.FromBase64String(message);
				using (ICryptoTransform decryptor = tdesAlgorithm.CreateDecryptor()) {
					results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
				}
			}
			return utf8.GetString(results);
		}

		#endregion

	}

	#endregion

}
