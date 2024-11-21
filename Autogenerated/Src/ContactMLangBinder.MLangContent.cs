namespace BPMSoft.Configuration
{
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: ContactMLangBinder

	/// <summary>
	/// Contact multilanguage class binder.
	/// </summary>
	public class ContactMLangBinder : AppEventListenerBase
	{

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<ILanguageIterator, ContactLanguageIterator>("Contact");
		}

		#endregion

	}

	#endregion

}
