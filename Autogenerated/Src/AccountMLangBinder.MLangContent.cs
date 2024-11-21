namespace BPMSoft.Configuration
{
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: AccountMLangBinder

	/// <summary>
	/// Account multilanguage class binder.
	/// </summary>
	public class AccountMLangBinder : AppEventListenerBase
	{

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<ILanguageIterator, AccountLanguageIterator>("Account");
		}

		#endregion

	}

	#endregion

}
