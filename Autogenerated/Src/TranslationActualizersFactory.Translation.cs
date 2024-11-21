namespace BPMSoft.Configuration.Translation
{
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Class: TranslationActualizersFactory

	[DefaultBinding(typeof(ITranslationActualizersFactory))]
	public class TranslationActualizersFactory : ITranslationActualizersFactory
	{

		#region Constants: Private

		private const string TranslationSchemaName = "SysTranslation";

		#endregion

		#region Constructors: Public

		public TranslationActualizersFactory(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private bool _isTranslationsCountInitialized;
		private int _translationsCount;
		private int TranslationsCount {
			get {
				if (!_isTranslationsCountInitialized) {
					Select translationsCountSelect =
						new Select(UserConnection)
							.Column(Func.Count(Column.Parameter(1)))
						.From(TranslationSchemaName);
					_translationsCount = translationsCountSelect.ExecuteScalar<int>();
					_isTranslationsCountInitialized = true;
				}
				return _translationsCount;
			}
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection {
			get;
			set;
		}

		private ITranslationLogger _translationLogger;
		private ITranslationLogger TranslationLogger {
			get {
				return _translationLogger ?? (_translationLogger = new TranslationLogger(UserConnection));
			}
		}

		#endregion

		#region Methods: Private

		private ITranslationProvider GetTranslationProvider() {
			return TranslationsCount > 0
				? CreateTranslationProvider<TranslationProvider>()
				: CreateTranslationProvider<TranslationBatchProvider>();
		}

		private ITranslationProvider CreateTranslationProvider<T>() where T : class, ITranslationProvider {
			return ClassFactory.Get<T>(new ConstructorArgument("userConnection", UserConnection),
				new ConstructorArgument("translationLogger", TranslationLogger));
		}

		private ISysCultureInfoProvider GetSysCultureInfoProvider() {
			return ClassFactory.Get<SysCultureInfoProvider>(
				new ConstructorArgument("userConnection", UserConnection));
		}

		private ITranslationActualizer GetTranslationActualizer(ITranslationProvider translationProvider,
				ISysCultureInfoProvider sysCultureInfoProvider) {
			return TranslationsCount > 0
				? CreateTranslationActualizer<TranslationActualizer>(translationProvider, sysCultureInfoProvider)
				: CreateTranslationActualizer<TranslationBatchActualizer>(translationProvider, sysCultureInfoProvider);
		}

		private ITranslationActualizer CreateTranslationActualizer<T>(ITranslationProvider translationProvider,
				ISysCultureInfoProvider sysCultureInfoProvider) where T : class, ITranslationActualizer {
			return ClassFactory.Get<T>(new ConstructorArgument("resourceProvider", null),
				new ConstructorArgument("translationProvider", translationProvider),
				new ConstructorArgument("sysCultureInfoProvider", sysCultureInfoProvider),
				new ConstructorArgument("translationLogger", TranslationLogger));
		}

		#endregion

		#region Methods: Public

		public ITranslationActualizer GetTranslationActualizer() {
			ITranslationProvider translationProvider = GetTranslationProvider();
			ISysCultureInfoProvider sysCultureInfoProvider = GetSysCultureInfoProvider();
			return GetTranslationActualizer(translationProvider, sysCultureInfoProvider);
		}

		#endregion

	}

	#endregion

}

