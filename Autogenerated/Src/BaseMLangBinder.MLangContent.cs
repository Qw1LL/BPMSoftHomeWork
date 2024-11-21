namespace BPMSoft.Configuration
{
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: BaseMLangBinder

	/// <summary>
	/// Base multilanguage class binder.
	/// </summary>
	public class BaseMLangBinder : AppEventListenerBase
	{

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<IContentKit, MLangContentKit>();
			ClassFactory.Bind<IContentStore, EmailTplContentStore>("EmailTemplate");
			ClassFactory.Bind<ILanguageIterator, DefaultLanguageIterator>("Default");
		}

		#endregion

	}

	#endregion

}
