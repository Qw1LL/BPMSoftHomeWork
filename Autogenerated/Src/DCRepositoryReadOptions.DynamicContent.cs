namespace BPMSoft.Configuration.DynamicContent
{
	using BPMSoft.Configuration.DynamicContent.Models;

	#region Class: DCRepositoryReadOptions

	/// <summary>
	/// Repository options for reads template.
	/// </summary>
	/// <typeparam name="T1">Template class.</typeparam>
	/// <typeparam name="T2">Replica class.</typeparam>
	public class DCRepositoryReadOptions<T1, T2> where T1: DCTemplateModel where T2: DCReplicaModel
	{

		#region Properties: Public

		/// <summary>
		/// Options flags for reads template. Default value is <see cref="DCTemplateReadOption.None"/>
		/// </summary>
		public DCTemplateReadOption TemplateReadOptions { get; set; } = DCTemplateReadOption.None;

		#endregion

	}

	#endregion

}
