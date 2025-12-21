namespace Darkness.Core.Contents
{
	public interface IContent
	{
		public string Id { get; }
		public T? GetComponent<T>() where T : struct, IContentComponent;
		public bool HasComponent<T>() where T : struct, IContentComponent;
		public bool TryGetComponent<T>(out T? component) where T : struct, IContentComponent;
		public void SetComponent<T>(T component) where T : struct, IContentComponent;
	}
}