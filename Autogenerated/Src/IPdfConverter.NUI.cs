namespace BPMSoft.Configuration
{
	/// <summary>
	/// Interface for convert ms word report to pdf.
	/// </summary>
	public interface IPdfConverter {

		/// <summary>
		/// Convert ms word data to pdf format.
		/// </summary>
		/// <param name="data">Ms word bytes data.</param>
		/// <returns>Pdf bytes data.</returns>
		byte[] Convert(byte[] data);
	}
}

