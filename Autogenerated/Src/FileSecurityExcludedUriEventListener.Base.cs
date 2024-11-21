namespace BPMSoft.Configuration
{
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.FileSecurity;

	#region Class: FileSecurityExcludedUriEventListener

	/// <summary>
	/// Listener for 'FileSecurityExcludedUri' entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "FileSecurityExcludedUri")]
	public class FileSecurityExcludedUriEventListener : BaseEntityEventListener
	{

		#region Fields: Private

		private readonly IFileSecurityExcludedUrisProvider _provider;

		#endregion

		#region Constructors: Internal

		internal FileSecurityExcludedUriEventListener(IFileSecurityExcludedUrisProvider provider) {
			provider.CheckArgumentNull(nameof(provider));
			_provider = provider;
		}

		#endregion

		#region Constructors: Public

		public FileSecurityExcludedUriEventListener() : this(ClassFactory.Get<IFileSecurityExcludedUrisProvider>()) {
		}

		#endregion

		#region Methods: Private

		private void ResetCache() {
			_provider.ResetCache();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			ResetCache();
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			ResetCache();
		}

		#endregion

	}

	#endregion

}

