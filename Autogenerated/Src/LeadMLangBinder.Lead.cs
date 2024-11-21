namespace BPMSoft.Configuration
{
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: LeadMLangBinder

	/// <summary>
	/// Lead multilanguage class binder.
	/// </summary>
	public class LeadMLangBinder : AppEventListenerBase
	{

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<ILanguageIterator, LeadLanguageIterator>("Lead");
		}

		#endregion

	}

	#endregion

}
