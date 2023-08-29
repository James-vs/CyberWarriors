mergeInto(LibraryManager.library, {
  RequestWebSession: function () {
	window.dispatchReactUnityEvent("RequestWebSession");
  },
});