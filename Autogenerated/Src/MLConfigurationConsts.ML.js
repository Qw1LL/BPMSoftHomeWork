define("MLConfigurationConsts", [], function() {
	const problemTypes = {
		Classification: "878ebe11-b0f3-43ae-88a5-e28c4f1dc4e3",
		Scoring: "183c45b3-f5fe-4efd-b993-2106e5e6dfd5",
		Regression: "3170a242-49e3-4fd9-99ed-0d6317bdda0a",
		CF: "7a80c1fa-6ae3-4001-9e5e-af07aedddd14",
		TextSimilarity: "ab660b9a-ab35-45f1-be3a-5b383d6e5a6c"
	};
	const mlTaskStartMethods = {
		Automatically: "2c8ddf9a-c19c-42cb-b143-e988ab1ac0b5",
		Manually: "d4b4c6e4-a344-48f4-85cb-67773cf73831"
	};
	const modelStates = {
		NotStarted: {
			id: "a241f7fd-00dc-4c4e-a461-f86c5663d630",
			code: "NotStarted",
			stageNumber: 1
		},
		DataTransferring: {
			id: "9c444d48-1cd8-4575-80e9-8c0057dd5776",
			code: "DataTransferring",
			stageNumber: 2
		},
		QueuedToTrain: {
			id: "b2f8460a-6e2d-477d-8238-a812fbce2621",
			code: "QueuedToTrain",
			stageNumber: 3
		},
		Training: {
			id: "0d94e73f-1672-4b24-a935-edc741825dce",
			code: "Training",
			stageNumber: 4
		},
		Done: {
			id: "8659b6bd-ed04-47ce-a96a-3055c7765e98",
			code: "Done",
			stageNumber: 5
		},
		Error: {
			id: "3cb4ab63-b709-4982-83c4-53fbc888f333",
			code: "Error",
			stageNumber: -1
		}
	};
	const finiteModelStates = [modelStates.NotStarted, modelStates.Done, modelStates.Error];

	const confidentValueMethods = {
		MLEngineSignificance: "5ce3f5dc-f541-4d6c-b7f8-819c33139b7f",
		MaximumProbability: "3cb6325e-0ecf-45f9-b56b-1e950d1f629b"
	};

	const mLModelColumnTypes = {
		Training: "4009205D-D3A6-4DFC-8CF4-449FCB91B930",
		Prediction: "12263EBE-0694-4ECD-8362-36244733D00A"
	};

	return {
		ProblemTypes: problemTypes,
		MLTaskStartMethods: mlTaskStartMethods,
		ModelStates: modelStates,
		FiniteModelStates: finiteModelStates,
		ConfidentValueMethods: confidentValueMethods,
		MLModelColumnTypes: mLModelColumnTypes
	};
});
