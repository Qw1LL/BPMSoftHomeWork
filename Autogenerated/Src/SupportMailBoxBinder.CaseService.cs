namespace BPMSoft.Configuration
{
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: SupportMailBoxBinder

	/// <summary>
	/// Binder for <see cref="ISupportMailBoxRepository"/>.
	/// </summary>
	public class SupportMailBoxBinder : AppEventListenerBase
	{

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<ISupportMailBoxRepository, SupportMailBoxRepository>("MailBoxRepository");
		}

		#endregion

	}

	#endregion

}
