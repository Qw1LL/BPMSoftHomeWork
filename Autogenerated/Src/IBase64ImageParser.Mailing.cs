namespace BPMSoft.Configuration.Mailing
{
	#region Interface: IBase64ImageParser

	/// <summary>
	/// Represents interface for parsing HTMLImageElement source into 
	/// <see cref="BPMSoft.Configuration.Mailing.Base64Image"/>.
	/// </summary>
	public interface IBase64ImageParser
	{
		/// <summary>
		/// Converts the string representation of an image in a 
		/// <see cref="BPMSoft.Configuration.Mailing.Base64Image"/>.
		/// </summary>
		/// <param name="src">Source of an image to convert.</param>
		/// <param name="image">Instance of the <see cref="BPMSoft.Configuration.Mailing.Base64Image"/> if 
		/// parsing was successful, otherwise null.</param>
		/// <returns>Returns true if parsing was successful, otherwise false.</returns>
		bool TryParse(string src, out Base64Image image);
	}

	#endregion

}
